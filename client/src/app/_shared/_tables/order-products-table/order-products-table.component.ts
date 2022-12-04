import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { OrderProduct } from 'src/app/_models/OrderProduct';
import { OrderProductsService } from 'src/app/_services/order-products.service';
import { OrderProductsTableDataSource } from './order-products-table-datasource';

@Component({
  selector: 'app-order-products-table',
  templateUrl: './order-products-table.component.html',
  styleUrls: ['./order-products-table.component.css']
})
export class OrderProductsTableComponent implements OnInit {
  @ViewChild(MatTable) table!: MatTable<OrderProduct>;
  @Input() initialData?: OrderProduct[];
  @Input() matElevationValue?: number = 8;
  @Input() fixedSize?: boolean = true;

  dataSource: OrderProductsTableDataSource;
  displayedColumns = ['approvedProductName', 'count', 'approvedSalesPriceGross', 'actions'];

  constructor(public orderProductsService: OrderProductsService) {}

  ngOnInit(): void {
    // Create DataSource (with initialData if needed)
    this.dataSource = new OrderProductsTableDataSource(this.orderProductsService, this.initialData);
  }

  ngAfterViewInit(): void {
    this.table.dataSource = this.dataSource;
  }

  onDeleteClick(orderProduct: OrderProduct) {
    this.dataSource.deleteOrderProduct(orderProduct.id);
  }
}