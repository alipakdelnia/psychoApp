import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserService } from './features/user/user.service';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,NgFor],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'admin-panel';
  users: any[] = [];

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.getUsers().subscribe(
      data => this.users = data
    );
  }
}
