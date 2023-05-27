import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { interval } from 'rxjs';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-orders-screen',
  templateUrl: './orders-screen.component.html',
  styleUrls: ['./orders-screen.component.css']
})
export class OrdersScreenComponent implements OnInit {
  orders: any[]=[];
  newOrder: any = {};
  connection: signalR.HubConnection;

  constructor(private http: HttpClient) { 
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/orders') // Replace with your SignalR hub URL
      .build();
  }

  ngOnInit() {
    this.fetchOrders();
    interval(10000).subscribe(() => {
      this.fetchOrders();
    });

    this.connection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:5001/orders') // Replace with your SignalR hub URL
    .build();

    this.connection.on('NewOrderCreated', () => {
      this.fetchOrders();
      this.newOrder = {}; // Clear the form
    });

    this.connection.start().catch(err => console.error(err));
  }

  fetchOrders() {
    this.http.get<any[]>('https://localhost:5001/api/Orders/GetOrders')
      .subscribe(orders => {
        this.orders = orders;
      });
  }

  createOrder() {
    this.http.post('https://localhost:5001/api/Orders/CreateOrder', this.newOrder)
      .subscribe(() => {
        this.connection.invoke('NotifyNewOrder');
      });
  }
}