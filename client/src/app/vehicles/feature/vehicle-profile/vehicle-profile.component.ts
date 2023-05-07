import { ClientSelectInputComponent } from '../../../shared/ui/selectors/client-select-input/client-select-input.component';
import { SnackbarService } from 'src/app/shared/ui/snackbar/snackbar.service';
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Vehicle } from '../../../core/models/Vehicle';
import { VehiclesService } from '../../data-access/vehicles.service';
import { Order } from 'src/app/core/models/Order';
import { OrdersTableComponent } from 'src/app/orders/ui/orders-table/orders-table.component';
import { finalize } from 'rxjs';
import { Client } from 'src/app/core/models/Client';
import { CreateOrderDialogComponent } from 'src/app/orders/ui/create-order-dialog/create-order-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { CanDeactivateComponent } from 'src/app/core/guards/can-deactivate.guard';

const NUMBER_REGEX = /^\d+$/;

@Component({
  selector: 'app-vehicle-profile',
  templateUrl: './vehicle-profile.component.html',
  styleUrls: ['./vehicle-profile.component.scss']
})
export class VehicleProfileComponent implements OnInit, AfterViewInit, CanDeactivateComponent {
  @ViewChild(OrdersTableComponent) ordersTable!: OrdersTableComponent;
  @ViewChild(ClientSelectInputComponent) clientSelect!: ClientSelectInputComponent;
  vehicle: Vehicle;
  currentOwner?: Client;
  editForm: FormGroup = this.formBuilder.group({
    brand: ['', [Validators.required]],
    model: ['', [Validators.required]],
    color: [''],
    registrationNumber: [''],
    productionDate: ['', [Validators.pattern(NUMBER_REGEX)]],
    currentOwner: [''],
    engineFuel: [''],
    vin: [''],
    engineCode: [''],
    capacity: ['', [Validators.pattern(NUMBER_REGEX)]],
    enginePower: ['', [Validators.pattern(NUMBER_REGEX)]],
    technicalInspectionEnd: [''],
    firstRegistration: [''],
    description: ['']
  });
  displayFinished: boolean = false;
  isSaving: boolean = false;

  constructor(
    private vehiclesService: VehiclesService,
    private formBuilder: FormBuilder,
    private snackbarService: SnackbarService,
    private activatedRoute: ActivatedRoute,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadVehicle();
  }

  ngAfterViewInit(): void {}

  onSaveChanges() {
    this.isSaving = true;
    const currentOwner = this.clientSelect.selectedClient;

    const updateData = { ...this.editForm.value, currentOwnerId: currentOwner?.id ?? null };

    this.vehiclesService
      .updateVehicle(this.vehicle.id, updateData)
      .pipe(
        finalize(() => {
          this.isSaving = false;
        })
      )
      .subscribe({
        next: () => {
          this.currentOwner = currentOwner;
          this.vehicle = { ...this.vehicle, ...updateData }; // Update specific props -> really handy
          this.snackbarService.showMessage('success', 'Pomyślnie zaktualizowano dane pojazdu');
          this.editForm.reset(this.vehicle);
        },
        error: (error) => {
          this.snackbarService.showMessage('error', error);
        }
      });
  }

  loadVehicle() {
    const vehicleId = Number(this.activatedRoute.snapshot.paramMap.get('id'));

    this.vehiclesService.getVehicle(vehicleId).subscribe((vehicle) => {
      // Store client and current owner data
      this.vehicle = vehicle;
      this.currentOwner = vehicle.currentOwner;

      // this.clientSelect.selectedClient = this.currentOwner;

      // Obtain owner name
      let currentOwnerName = '';
      if (this.currentOwner) {
        currentOwnerName =
          vehicle.currentOwner.type === 'company'
            ? vehicle.currentOwner.companyName
            : vehicle.currentOwner.firstname + ' ' + vehicle.currentOwner.lastname;
      }

      // Fill form
      this.editForm.setValue({
        brand: vehicle.brand,
        model: vehicle.model,
        color: vehicle.color,
        registrationNumber: vehicle.registrationNumber,
        productionDate: vehicle.productionDate,
        currentOwner: currentOwnerName,
        engineFuel: vehicle.engineFuel,
        vin: vehicle.vin,
        engineCode: vehicle.engineCode,
        capacity: vehicle.capacity,
        enginePower: vehicle.enginePower,
        technicalInspectionEnd: vehicle.technicalInspectionEnd,
        firstRegistration: vehicle.firstRegistration,
        description: vehicle.description
      });
    });
  }

  getCurrentDate() {
    return new Date();
  }

  onToggleChange() {
    this.displayFinished = !this.displayFinished;
    this.displayFinished
      ? this.ordersTable.dataSource.setOrders(this.vehicle.orders)
      : this.ordersTable.dataSource.setOrders(this.filterFinshedOrders(this.vehicle.orders));
  }

  filterFinshedOrders(orders: Order[]) {
    return orders.filter((order) => order.status.position !== 4);
  }

  onAddOrder() {
    const dialogRef = this.dialog.open(CreateOrderDialogComponent, {
      width: '800px',
      data: { vehicle: this.vehicle }
    });
    dialogRef.afterClosed().subscribe((order: Order) => {
      if (order !== undefined) this.ordersTable.dataSource.addOrder(order);
    });
  }

  canDeactivate() {
    return !this.editForm.dirty || confirm('Are you sure to unsaved the current changes?');
  }
}