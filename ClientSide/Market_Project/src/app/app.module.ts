import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MarketScreenComponent } from './market-screen/market-screen.component';
import { OrdersScreenComponent } from './orders-screen/orders-screen.component';

@NgModule({
  declarations: [
    AppComponent,
    MarketScreenComponent,
    OrdersScreenComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }