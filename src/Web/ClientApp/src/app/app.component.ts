import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavMenuComponent } from './shared/components/nav-menu/nav-menu.component';
import { SideNavComponent } from './shared/components/side-nav/side-nav.component';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    standalone: true,
    imports: [NavMenuComponent, RouterOutlet, SideNavComponent]
})
export class AppComponent {
  title = 'app';
}
