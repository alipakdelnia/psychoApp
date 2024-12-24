import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UsersComponent } from "./features/users/users.component";
import { LanguageService } from './language-service.service';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, UsersComponent,NgClass],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent{
  title = 'PsychoApp_AdminPanel';

  constructor(private languageService: LanguageService) {}



  setLanguage(lang: 'en' | 'fa'): void {
    this.languageService.setLanguage(lang);
  }
  
}
