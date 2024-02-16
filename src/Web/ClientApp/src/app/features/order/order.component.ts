import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormsModule } from '@angular/forms';
import { MenuItem, MenuItemsClient, 
  Order, OrdersClient, CreateOrderCommand, NewOrderDto } from '../../shared/services/web-api-client';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, FormsModule],
  templateUrl: './order.component.html',
  styles: ``
})
export class OrderComponent implements OnInit{
  public menuItems: MenuItem[] = [];
  public orderedItems: MenuItem[] = [];
  public order: Order;
  public newOrder: NewOrderDto[] = [];

  constructor(
    private menuClient: MenuItemsClient, 
    private orderClient: OrdersClient,
    private _snackBar: MatSnackBar,
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
    this.order.items.push(menuItem);// Current work around to display name for now
    var item = new NewOrderDto({menuItemId: menuItem.id, itemQuantity: 1})
    if (this.newOrder.filter((item) => item.menuItemId == menuItem.id).length > 0) {
      this.newOrder.find((item) => item.menuItemId == menuItem.id).itemQuantity++;
      return;
    }
    this.newOrder.push(item); 
  }

  sendOrder() : void {
    this.orderClient.createOrder({items: this.newOrder} as CreateOrderCommand).subscribe();
    this.displaySuccessSnackBar();
    this.order = new Order;
    this.order.items = [];
  }

  displaySuccessSnackBar(): void {
    this._snackBar.open("Order sent", "close", {
      duration: 3000,
      verticalPosition: 'top',
    });
  }

}
