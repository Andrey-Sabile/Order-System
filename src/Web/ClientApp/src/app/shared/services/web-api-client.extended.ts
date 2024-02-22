import { Observable } from 'rxjs';// ignore
import { interval, switchMap, startWith, repeat } from 'rxjs';
import * as generated from './web-api-client';

class OrdersClient extends generated.OrdersClient{
    getOrdersUpdated(): Observable<OrderDto[]> {
        return this.getOrders()
            .pipe(
                repeat({delay:3000})
            )
      }
}