// signalr.service.ts
import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRServiceService {
  private hubConnection: signalR.HubConnection;

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/stocks') // Replace with your SignalR hub URL
      .build();
  }

  public startConnection(): Promise<void> {
    return this.hubConnection.start();
  }

  public stopConnection(): Promise<void> {
    return this.hubConnection.stop();
  }

  public subscribeToStockPriceUpdates(callback: (stockPrices: any[]) => void): void {
    this.hubConnection.on('UpdateStockPrices', callback);
  }

  public createOrder(orderData: any): Promise<void> {
    return this.hubConnection.invoke('CreateOrder', orderData);
  }
}