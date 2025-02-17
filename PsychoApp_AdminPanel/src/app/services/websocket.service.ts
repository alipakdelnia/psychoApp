import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WebsocketService {
  private socket!: WebSocket;
  private subject!: Subject<any>;

  constructor() {}

  connect(url: string): Observable<any> {
    if (!this.socket || this.socket.readyState !== WebSocket.OPEN) {
      this.socket = new WebSocket(url);
      this.subject = new Subject();

      this.socket.onmessage = (event) => {
        this.subject.next(JSON.parse(event.data));
      };

      this.socket.onerror = (error) => {
        console.error('WebSocket Error:', error);
      };

      this.socket.onclose = () => {
        console.log('WebSocket Disconnected');
      };
    }
    return this.subject.asObservable();
  }

  sendMessage(message: any) {
    if (this.socket && this.socket.readyState === WebSocket.OPEN) {
      this.socket.send(JSON.stringify(message));
    } else {
      console.error('WebSocket is not connected.');
    }
  }

  disconnect() {
    if (this.socket) {
      this.socket.close();
    }
  }
}
