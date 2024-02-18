import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { Order, OrderDto, OrdersClient, UpdateOrderCommand, MenuItem, MenuItemsClient } from '../../shared/services/web-api-client';
import { filter } from 'rxjs';

@Component({
  selector: 'app-kitchendisplay',
  standalone: true,
  imports: [MatButtonModule, MatCardModule],
  templateUrl: './kitchendisplay.component.html',
})
export class KitchendisplayComponent implements OnInit{
  public orders: OrderDto[] = [];
  public remainingOrders: OrderDto[];
  public menuItems: MenuItem[] = [];

  constructor(
    private orderClient: OrdersClient,
    private menuItemsClient: MenuItemsClient,

  ){}

  ngOnInit(): void {
    this.getOrders();
    this.getItems();
  }

  getOrders(): void {
    this.orderClient.getOrders().subscribe({
      next: result => {
        this.orders = result
        this.remainingOrders = this.orders.filter(order => !order.done)
      },
      error : error => console.error(error),
    });
  }

  orderCompleted(id: number): void {
    this.orderClient.updateOrder(id, { orderId: id } as UpdateOrderCommand).subscribe({
      next: result => this.remainingOrders = this.remainingOrders.filter(order => order.id !== id)
    });
  }

  getItems(): void {
    this.menuItemsClient.getMenuItems().subscribe({
      next: result => this.menuItems = result,
      error : error => console.error(error)
    });
  }

  getItemName(id: number): string|undefined {
    return this.menuItems.find(menuItem => menuItem.id === id)?.name
  }
}
