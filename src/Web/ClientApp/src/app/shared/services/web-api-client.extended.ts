import { Observable } from 'rxjs';// ignore
import { interval, switchMap, startWith } from 'rxjs';
import * as generated from './web-api-client';

class OrdersClient extends generated.OrdersClient{
    getOrdersUpdated(): Observable<OrderDto[]> {
        return interval(5000).pipe(
            startWith(0),
            switchMap(() => this.getOrders()),
        )
      }
}