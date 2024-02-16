import { Component, OnInit, Inject, ViewChild, } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { 
  MatDialog, 
  MatDialogModule,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose, } from '@angular/material/dialog';
import { MatTable, MatTableModule } from '@angular/material/table'
import { CreateMenuItemCommand, MenuItem, MenuItemsClient } from '../../shared/services/web-api-client';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [MatButtonModule, MatTableModule, MatDialogModule, MatFormFieldModule, MatInputModule, FormsModule],
  templateUrl: './menu.component.html',
  styles: ``
})
export class MenuComponent implements OnInit{
  public menuItems: MenuItem[] = [];
  public displayedColumns: string[] = ['name', 'price'];
  public menuItem: MenuItem;

  @ViewChild(MatTable) table: MatTable<MenuItem>;

  constructor(
    private menuClient: MenuItemsClient,
    public dialog: MatDialog,
  ){}

  ngOnInit(): void {
    this.menuClient.getMenuItems().subscribe({
      next: result => this.menuItems = result,
      error: error => console.log(error)
    });

    this.menuItem = new MenuItem;
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogMenuComponent, {
      data: {name: this.menuItem.name, price: this.menuItem.price},
    });

    dialogRef.afterClosed().subscribe({
      next: result => {
        this.menuClient.createMenuItem(result as CreateMenuItemCommand).subscribe();
        this.menuItems.push(result);
        this.table.renderRows();
      },
      error: error => console.log(error.error)
    })
  }

  removeItem(itemId: number): void {
    this.menuClient.deleteMenuItem(itemId).subscribe({
      next: result => {
        this.menuItems = this.menuItems.filter(menuItem => menuItem.id !== itemId);
        this.table.renderRows();
      }
    })
  } 

}

@Component({
  selector: 'dialog-app-menu',
  templateUrl: './dialog-menu.component.html',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
  ]
})
export class DialogMenuComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA) public menuItem: MenuItem,
    public dialogRef: MatDialogRef<DialogMenuComponent>,
  ) {}

  onSubmit(menuItem: MenuItem): void {
    this.dialogRef.close(menuItem);
  }
}