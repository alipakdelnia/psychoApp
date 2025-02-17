import { Component } from '@angular/core';
import { WebsocketService } from '../../services/websocket.service';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'app-chat-screen',
  standalone: true,
  imports: [],
  templateUrl: './chat-screen.component.html',
  styleUrl: './chat-screen.component.css'
})
export class ChatScreenComponent {
  messages: string[] = [];
  newMessage: string = '';
  private socketUrl = 'ws://http://localhost:5087'; 

  constructor(private wsService: WebsocketService) {}

  ngOnInit() {
    this.wsService.connect(this.socketUrl).subscribe((message) => {
      this.messages.push(message);
    });
  }

  sendMessage() {
    if (this.newMessage.trim()) {
      this.wsService.sendMessage(this.newMessage);
      this.newMessage = '';
    }
  }

  ngOnDestroy() {
    this.wsService.disconnect();
  }
}
