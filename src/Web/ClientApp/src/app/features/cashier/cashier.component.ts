import { Component, OnInit, OnDestroy } from '@angular/core';
import { OrderDto, OrdersClient, UpdateOrderCommand } from 'src/app/shared/services/web-api-client';
import { Subscription, repeat } from 'rxjs';

@Component({
  selector: 'app-cashier',
  standalone: true,
  imports: [],
  templateUrl: './cashier.component.html',
  styles: ``
})
export class CashierComponent implements OnInit, OnDestroy{
  public unpaidOrders: OrderDto[];
  unpaidOrdersSubscription$: Subscription;
  public selectedUnpaidOrder: OrderDto;

  constructor(
    private orderClient: OrdersClient,
  ){}

  ngOnInit(): void {
    this.getUnpaidOrders();
    this.selectedUnpaidOrder = new OrderDto;
  }

  getUnpaidOrders(): void {
    this.unpaidOrdersSubscription$ = this.orderClient.getOrders().pipe(repeat({delay:10000})).subscribe({
      next: result => {
        this.unpaidOrders = result;
        this.unpaidOrders = this.unpaidOrders.filter(order => !order.paid);
        console.log()
      },
      error: error => console.error(error),
    });
  }

  ngOnDestroy(): void {
    this.unpaidOrdersSubscription$.unsubscribe();
  }

  setUnpaidOrder(selectedOrder: OrderDto): void {
    this.selectedUnpaidOrder = selectedOrder;
  }

  calculateTotalPrice(quantity: number, price: number): number {
    return quantity * price;
  }

  payOrder(selectedOrder: OrderDto): void {
    const command = {
      orderId: selectedOrder.id,
      done: true,
      paid: true,
    } as UpdateOrderCommand

    this.orderClient.updateOrder(command.orderId, command).subscribe({
      next: () => this.unpaidOrders = this.unpaidOrders.filter(order => order.id !== command.orderId)
    });
  }
}
