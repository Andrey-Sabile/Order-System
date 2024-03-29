import { enableProdMode } from '@angular/core';
import { environment } from './environments/environment';
import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { config } from './app/app.config.server';

if (environment.production) {
  enableProdMode();
}

bootstrapApplication(AppComponent, config)
  .catch((err) => console.error(err));