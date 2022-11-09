import { DateAndTimePickerEvent } from './../../../_shared/date-and-time-picker/date-and-time-picker.component';
import { SnackbarService } from 'src/app/_services/snackbar.service';
import { Component, OnInit, ViewChild, AfterViewInit, Input } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { Order } from 'src/app/_models/Order';
import { OrdersService } from 'src/app/_services/orders.service';
import { OrdersTableDataSource } from './orders-table-datasource';
import { Status } from 'src/app/_models/Status';

@Component({
  selector: 'app-orders-table',
  templateUrl: './orders-table.component.html',
  styleUrls: ['./orders-table.component.css']
})
export class OrdersTableComponent implements OnInit, AfterViewInit {

  @ViewChild(MatPaginator) paginator!: MatPaginator;    // ! - assured that paginator exists
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<Order>;
  @Input() initialData?: Order[];
  @Input() hideClientColumn?: boolean = false;
  @Input() hideVehicleColumn?: boolean = false;
  @Input() matElevationValue?: number = 8;
  @Input() fixedSize?: boolean = true;

  dataSource: OrdersTableDataSource;
  displayedColumns= ["orderNumber", "createDate", "finishDate", "status", "client", "vehicle", "admissionDate", "deadlineDate", "totalGross", "actions"];
                      

  
  constructor(public ordersService: OrdersService,
              private snackbarService: SnackbarService) {}
  
  ngOnInit(): void {
    this.dataSource = new OrdersTableDataSource(this.ordersService);

    // Hide client or/and vehicle column if needed
    this.displayedColumns = this.displayedColumns
      .filter((column) => !((column === 'client' && this.hideClientColumn) || (column === 'vehicle' && this.hideVehicleColumn)));

    this.initialData && this.dataSource.setOrders(this.initialData);
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }

  onAdmissionDateChange(event: DateAndTimePickerEvent, orderId: number){

    let orderToUpdate = this.dataSource.getOrders().find(order => order.id === orderId)
    if(!orderToUpdate){
      this.snackbarService.showMessage('error', "Niepoprawne id zlecenia");
    }

    this.ordersService.updateOrderPatch(orderId, {admissionDate: event.date}).subscribe({
      next: () => {
        this.snackbarService.showMessage('success', "Pomyślnie zaktualizowano datę");
      },
      error: (error) => {
        console.log(error);
        this.snackbarService.showMessage('error', "Nie udało się zaktualizować daty");
        // Restore previous date
        event.restorePreviousDate();
      }
    })
  }

  onDeadlineDateChange(event: DateAndTimePickerEvent, orderId: number){
    let orderToUpdate = this.dataSource.getOrders().find(order => order.id === orderId)
    if(!orderToUpdate){
      this.snackbarService.showMessage('error', "Niepoprawne id zlecenia");
    }

    this.ordersService.updateOrderPatch(orderId, {deadlineDate: event.date}).subscribe({
      next: () => {
        this.snackbarService.showMessage('success', "Pomyślnie zaktualizowano datę");
      },
      error: (error) => {
        console.log(error);
        this.snackbarService.showMessage('error', "Nie udało się zaktualizować daty");
        // Restore previous date
        event.restorePreviousDate();
      }
    })
  }

  onStatusUpdate(updatedStatus: Status){

    // Find corresponding order
    const orderToUpdate = this.dataSource.getOrders().find((order) => order.status.id == updatedStatus.id);

    this.ordersService.updateOrder({...orderToUpdate, finishDate: new Date()}).subscribe({
      next: (order: Order) => {
        // Update table
        let updatedOrders = this.dataSource.getOrders().map((o) => o.id === order.id ? {...o, finishDate: order.finishDate, status: updatedStatus} : o);
        this.dataSource.setOrders(updatedOrders);
      },
      error: () => {
        this.snackbarService.showMessage('error', "Nie udało się zaktualizować daty zmiany statusu");
      }
    })
  }

}
