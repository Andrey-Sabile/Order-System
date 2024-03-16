import { Component, OnDestroy, OnInit } from '@angular/core';
import { OrderDto, OrdersClient, UpdateOrderCommand, MenuItem, MenuItemsClient } from '../../shared/services/web-api-client';
import { Subscription, repeat } from 'rxjs';

@Component({
  selector: 'app-kitchendisplay',
  standalone: true,
  imports: [],
  templateUrl: './kitchendisplay.component.html',
})
export class KitchendisplayComponent implements OnInit, OnDestroy{
  public remainingOrders: OrderDto[];
  public menuItems: MenuItem[] = [];
  menuItemsSubscription$: Subscription;

  constructor(
    private orderClient: OrdersClient,
    private menuItemsClient: MenuItemsClient,
  ){}

  ngOnInit(): void {
    this.getOrders();
    this.getItems();
  }

  getOrders(): void {
    this.menuItemsSubscription$ = this.orderClient.getOrders().pipe(repeat({delay:3000})).subscribe({
      next: result => {
        this.remainingOrders = result;
        this.remainingOrders = this.remainingOrders.filter(order => !order.done);
      },
      error: error => console.error(error),
    });
  }

  ngOnDestroy(): void {
    this.menuItemsSubscription$.unsubscribe();
  }

  orderCompleted(id: number): void {
    const command = {
      orderId: id,
      done: true,
      paid: false,
    } as UpdateOrderCommand
    
    this.orderClient.updateOrder(id, command).subscribe({
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
