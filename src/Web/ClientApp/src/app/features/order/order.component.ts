import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MenuItem, MenuItemsClient, 
  Order, OrdersClient, CreateOrderCommand } from '../../shared/services/web-api-client';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, FormsModule],
  templateUrl: './order.component.html',
  styles: ``
})
export class OrderComponent implements OnInit{
  public menuItems: MenuItem[] = [];
  public order: Order;

  constructor(
    private menuClient: MenuItemsClient, 
    private orderClient: OrdersClient
    ){}

  ngOnInit(): void {
    this.menuClient.getMenuItems().subscribe({
      next: result => this.menuItems = result,
      error : error => console.error(error)
    });
    this.order = new Order;
    this.order.items = [];
  }

  addItem(menuItem: MenuItem) : void {
    this.order.items.push(menuItem);
  }

  sendOrder() : void {
    const ids = this.order.items.map(({id}) => id);
    this.orderClient.createOrder({ menuItemIds: ids } as CreateOrderCommand).subscribe();
  }

}
