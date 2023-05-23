import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatTabsModule } from '@angular/material/tabs';
import { MatButtonModule } from '@angular/material/button';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { TextInputModule } from 'src/app/shared/ui/inputs/text-input/text-input.module';
import { ReactiveFormsModule } from '@angular/forms';
import { CustomHeaderModule } from 'src/app/shared/ui/custom-header/custom-header.module';
import { OrdersTableModule } from 'src/app/features/orders/ui/orders-table/orders-table.module';
import { ProductProfileRoutingModule } from './product-profile-routing.module';
import { ProductProfileComponent } from './product-profile.component';
import { TableBaseDirectiveModule } from 'src/app/shared/ui/directives/table-base-directive/table-base-directive.module';

@NgModule({
  declarations: [ProductProfileComponent],
  imports: [
    CommonModule,
    ProductProfileRoutingModule,
    MatIconModule,
    MatTabsModule,
    MatButtonModule,
    MatSlideToggleModule,
    TextInputModule,
    ReactiveFormsModule,
    CustomHeaderModule,
    OrdersTableModule,
    TableBaseDirectiveModule
  ]
})
export class ProductProfileModule {}
