import { Component, OnInit,  } from '@angular/core';
import { CreateMenuItemCommand, MenuItem, MenuItemsClient } from '../../shared/services/web-api-client';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [ FormsModule],
  templateUrl: './menu.component.html',
  styles: ``
})
export class MenuComponent implements OnInit{
  public menuItems: MenuItem[] = [];
  public displayedColumns: string[] = ['name', 'price', 'button',];
  public menuItem: MenuItem;
  public newMenuItem: any = {};

  constructor(
    private menuClient: MenuItemsClient,
  ){}

  ngOnInit(): void {
    this.getMenuItems();
  }

  getMenuItems(): void {
    this.menuClient.getMenuItems().subscribe({
      next: result => this.menuItems = result,
      error: error => console.log(error)
    });
    this.menuItem = new MenuItem;
  }

  addItem(newMenuItem: any): void {
    const menuItem = {
      name: this.newMenuItem.name,
      price: this.newMenuItem.price
    } as CreateMenuItemCommand

    this.menuClient.createMenuItem(menuItem).subscribe({
      next: result => {
        if (result !== undefined)
        {
          this.menuItems.push(menuItem);
          this.newMenuItem = {};
        }
      }
    })
  }

  removeItem(itemId: number): void {
    this.menuClient.deleteMenuItem(itemId).subscribe({
      next: result => {
        this.menuItems = this.menuItems.filter(menuItem => menuItem.id !== itemId);
      }
    })
  }
}