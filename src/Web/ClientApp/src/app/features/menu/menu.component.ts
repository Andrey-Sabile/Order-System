import { Component, OnInit,  } from '@angular/core';
import { CreateMenuItemCommand, MenuItem, MenuItemsClient, UpdateMenuItemCommand } from '../../shared/services/web-api-client';
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
  public newMenuItem: any = {};
  public selectedMenuItem: MenuItem;

  constructor(
    private menuClient: MenuItemsClient,
  ){}

  ngOnInit(): void {
    this.getMenuItems();
    this.selectedMenuItem = new MenuItem;
  }

  getMenuItems(): void {
    this.menuClient.getMenuItems().subscribe({
      next: result => this.menuItems = result,
      error: error => console.log(error)
    });
  }

  addItem(newMenuItem: any): void {
    const menuItem = {
      name: this.newMenuItem.name,
      price: this.newMenuItem.price
    } as CreateMenuItemCommand;

    this.menuClient.createMenuItem(menuItem).subscribe({
      next: result => {
        if (result !== undefined)
        {
          const newItem = {
            id: result,
            name: menuItem.name,
            price: menuItem.price
          } as MenuItem
          this.menuItems.push(newItem);
          this.newMenuItem = {};
        }
      },
      error: error => {
        const errors = JSON.parse(error.response).errors;
        if (errors && errors.Name) {
          console.log(errors.Name[0]);
        }
        if (errors && errors.Price) {
          console.log(errors.Price[0]);
        }
      }
    })
  }

  setItemToUpdate(selectedItem: MenuItem): void {
    this.selectedMenuItem = selectedItem;
  }

  updateItem(item: MenuItem): void {
    const menuItem = {
      id: item.id,
      name: item.name,
      price: item.price,
    } as UpdateMenuItemCommand

    this.menuClient.updateMenuItem(item.id, menuItem).subscribe({
      next: result => {
        this.getMenuItems();
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