import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { UsersService } from './users.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [NgFor,RouterModule],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent implements OnInit{
  users: any[] = [];

  constructor(private usersService: UsersService) {}

  ngOnInit(): void {
    this.usersService.getUsers().subscribe(
      data => this.users = data
    );
  }
}
