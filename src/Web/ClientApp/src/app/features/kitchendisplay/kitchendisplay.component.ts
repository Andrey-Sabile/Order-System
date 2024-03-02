import { Component, OnInit } from '@angular/core';
import { OrderDto, OrdersClient, UpdateOrderCommand, MenuItem, MenuItemsClient } from '../../shared/services/web-api-client';

@Component({
  selector: 'app-kitchendisplay',
  standalone: true,
  imports: [],
  templateUrl: './kitchendisplay.component.html',
})
export class KitchendisplayComponent implements OnInit{
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
    this.orderClient.getOrdersUpdated().subscribe({
      next: result => {
        this.remainingOrders = result;
        this.remainingOrders = this.remainingOrders.filter(order => !order.done);
      },
      error: error => console.error(error),
    });
  }

  orderCompleted(id: number): void {
    this.orderClient.updateOrder(id, { orderId: id } as UpdateOrderCommand).subscribe({
      next: () => this.remainingOrders = this.remainingOrders.filter(order => order.id !== id)
    });
  }

  getItems(): void {
    this.menuItemsClient.getMenuItems().subscribe({
      next: result => this.menuItems = result,
      error : error => console.error(error)
    });
  }
}
