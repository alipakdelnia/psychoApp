import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UsersComponent } from "./features/users/users.component";
import { LanguageService } from './language-service.service';
import { NgClass } from '@angular/common';
import { TranslateDirective, TranslatePipe ,TranslateService} from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, UsersComponent,NgClass,TranslatePipe, TranslateDirective],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent{
  title = 'PsychoApp_AdminPanel';

  constructor(private translate: TranslateService) {
    this.translate.addLangs(['de', 'en']);
    this.translate.setDefaultLang('en');
    this.translate.use('en');
}

switchLanguage(lang: string): void {
  this.translate.use(lang);
  document.documentElement.lang = lang;
  document.documentElement.dir = lang === 'fa' ? 'rtl' : 'ltr'; // change html dir
}
  
}
