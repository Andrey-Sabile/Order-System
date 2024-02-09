import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { Order, OrdersClient } from '../../shared/services/web-api-client';

@Component({
  selector: 'app-kitchendisplay',
  standalone: true,
  imports: [MatButtonModule, MatCardModule],
  templateUrl: './kitchendisplay.component.html',
})
export class KitchendisplayComponent implements OnInit{
  public orders: Order[] = [];

  constructor(
    private orderClient: OrdersClient,
  ){}

  ngOnInit(): void {
    this.orderClient.getOrders().subscribe({
      next: result => this.orders = result,
      error : error => console.error(error),
    });
  }
}
