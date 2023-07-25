import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { VehicleFormGroup } from './vehicle-form-types';
import { Client } from 'src/app/core/models/Client';

const DEFAULT_VEHICLE_FORM_ID = 'vehicle-form'; // Purpose: attaching external buttons

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.scss']
})
export class VehicleFormComponent implements OnInit {
  @Input() formId: string = DEFAULT_VEHICLE_FORM_ID;
  @Input() vehicleForm!: VehicleFormGroup;
  @Input() vehicleOwner!: Client;
  @Output() onSubmit: EventEmitter<SubmitEvent> = new EventEmitter();
  @Output() onVehicleOwnerChange: EventEmitter<Client> = new EventEmitter();
  currentDate: Date;

  constructor() {}

  ngOnInit(): void {
    this.currentDate = new Date();
  }

  onSubmitForm(event: SubmitEvent) {
    this.onSubmit.emit(event);
  }

  onClientChange(client: Client) {
    this.onVehicleOwnerChange.emit(client);
  }
}
