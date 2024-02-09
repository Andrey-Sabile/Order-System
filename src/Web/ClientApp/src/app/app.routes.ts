import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { CounterComponent } from './features/counter/counter.component';
import { FetchDataComponent } from './features/fetch-data/fetch-data.component';
import { TodoComponent } from './features/todo/todo.component';
import { MenuComponent } from './features/menu/menu.component';
import { TablesComponent } from './features/tables/tables.component';

export const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent },
    { path: 'todo', component: TodoComponent },
    { path: 'menu', component: MenuComponent },
    { path: 'tables', component: TablesComponent},
]