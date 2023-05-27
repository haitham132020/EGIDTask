import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';
import {SignalR} from '@microsoft/signalr';
import { async } from 'rxjs';
if (environment.production) {
  enableProdMode();
}
export async function run() {
  const signalR=new SignalR();
  signalR.start();
}
run().catch(err=>console.error(err));
platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
