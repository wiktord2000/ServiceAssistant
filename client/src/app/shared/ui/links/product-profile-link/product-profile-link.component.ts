import { Product } from 'src/app/core/models/Product';
import { Component, Input, OnInit } from '@angular/core';
import { TooltipPosition } from '@angular/material/tooltip';
import { ThemePalette } from '@angular/material/core';

@Component({
  selector: 'app-product-profile-link',
  templateUrl: './product-profile-link.component.html',
  styleUrls: ['./product-profile-link.component.scss']
})
export class ProductProfileLinkComponent implements OnInit {
  @Input() product: Product;
  @Input() tooltipPosition: TooltipPosition = 'right';
  @Input() color: ThemePalette = 'primary';
  @Input() customColor?: string;
  @Input() containLabel: boolean = false;

  ngOnInit(): void {}
}
