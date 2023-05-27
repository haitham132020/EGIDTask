import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { interval } from 'rxjs';
//import { SignalRServiceService } from './signal-rservice.service.ts';

@Component({
  selector: 'app-market-screen',
  templateUrl: './market-screen.component.html',
  styleUrls: ['./market-screen.component.css']
})
export class MarketScreenComponent implements OnInit {
  stocks: any[]=[];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.fetchStocks();
    interval(10000).subscribe(() => {
      this.fetchStocks();
    });

    //this.signalRService.startConnection();
    //this.signalRService.addStockPriceUpdateListener((stockId: number, price: number) => {
     // const stock = this.stocks.find(s => s.id === stockId);
     // if (stock) {
      //  stock.price = price;
      //}
    //});
  }

  fetchStocks() {
    this.http.get<any[]>('https://localhost:5001/api/stocks')
      .subscribe(stocks => {
        this.stocks = stocks;
      });
  }
}