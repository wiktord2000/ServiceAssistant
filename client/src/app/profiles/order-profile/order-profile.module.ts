import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderProfileComponent } from './order-profile.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatDividerModule } from '@angular/material/divider';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { VehicleProfileLinkModule } from 'src/app/shared/components/links/vehicle-profile-link/vehicle-profile-link.module';
import { StatusSelectorModule } from 'src/app/shared/components/selectors/status-selector/status-selector.module';
import { ClientProfileLinkModule } from 'src/app/shared/components/links/client-profile-link/client-profile-link.module';
import { CustomHeaderModule } from 'src/app/shared/components/custom-header/custom-header.module';
import { ClientSelectInputModule } from 'src/app/shared/components/selectors/client-select-input/client-select-input.module';
import { TextInputModule } from 'src/app/shared/components/inputs/text-input/text-input.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { OrderServicesTableModule } from 'src/app/shared/components/tables/order-services-table/order-services-table.module';
import { OrderProductsTableModule } from 'src/app/shared/components/tables/order-products-table/order-products-table.module';
import { VehicleSelectInputModule } from 'src/app/shared/components/selectors/vehicle-select-input/vehicle-select-input.module';
import { DateAndTimeInputModule } from 'src/app/shared/components/inputs/date-and-time-input/date-and-time-input.module';

@NgModule({
  declarations: [OrderProfileComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatTabsModule,
    MatDividerModule,
    MatFormFieldModule,
    MatSelectModule,
    MatButtonModule,
    VehicleProfileLinkModule,
    StatusSelectorModule,
    ClientProfileLinkModule,
    CustomHeaderModule,
    TextInputModule,
    DateAndTimeInputModule,
    MatIconModule,
    OrderProductsTableModule,
    OrderServicesTableModule,
    ClientSelectInputModule,
    VehicleSelectInputModule
  ],
  exports: [OrderProfileComponent]
})
export class OrderProfileModule {}