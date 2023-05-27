import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MarketScreenComponent } from './market-screen/market-screen.component';
import { OrdersScreenComponent } from './orders-screen/orders-screen.component';

const routes: Routes = [
  { path: 'market', component: MarketScreenComponent },
  { path: 'order', component: OrdersScreenComponent },
  { path: '', redirectTo: '/market', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }