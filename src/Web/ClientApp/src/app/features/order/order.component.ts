import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormsModule } from '@angular/forms';
import { MenuItem, MenuItemsClient, 
  Order, OrdersClient, CreateOrderCommand, NewOrderDto } from '../../shared/services/web-api-client';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [ FormsModule,],
  templateUrl: './order.component.html',
  styles: ``
})
export class OrderComponent implements OnInit{
  public menuItems: MenuItem[] = [];
  public order: Order;
  public newOrder: NewOrderDto[] = [];
  public orderDto: NewOrderDto[] = [];
  public tableNumber?: number | undefined;

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
    if (this.itemExistInOrder(menuItem.id)) {
      this.increaseItemQuantity(menuItem.id);
      return;
    }

    this.order.items.push(menuItem);// Current work around to display name for now
    var item = new NewOrderDto({menuItemId: menuItem.id, itemQuantity: 1})
    this.newOrder.push(item);
  }

  itemExistInOrder(id: number): boolean {
    return this.newOrder.filter((item) => item.menuItemId == id).length > 0;
  }

  increaseItemQuantity(id: number): void {
    this.newOrder.find((item) => item.menuItemId == id).itemQuantity++;
  } 

  getItemQuantity(id: number): number {
    return this.newOrder.find((item) => item.menuItemId == id).itemQuantity; 
  }

  sendOrder() : void {
    if (this.newOrder.length <= 0) {
      this.displayEmptyOrderSnackBar();
      return;
    }

    const command = {
      tableNumber: this.tableNumber,
      items: this.newOrder
    } as CreateOrderCommand
    this.orderClient.createOrder(command).subscribe();
    
    this.displaySuccessSnackBar();
    
    this.order = new Order;
    this.order.items = [];
    this.newOrder = [];
    this.tableNumber = null;
  }

  displaySuccessSnackBar(): void {
    this._snackBar.open("Order sent", "close", {
      duration: 3000,
      verticalPosition: 'top',
    });
  }

  displayEmptyOrderSnackBar(): void {
    this._snackBar.open("Order empty!!", "close", {
      duration: 3000,
      verticalPosition: 'top',
    })
  }

  removeItem(itemId: number): void {
    this.order.items = this.order.items.filter((item) => item.id !== itemId);
    this.newOrder = this.newOrder.filter((item) => item.menuItemId !== itemId);
  }
}
