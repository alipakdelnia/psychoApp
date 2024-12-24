import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LanguageService {
  currentLang: 'en' | 'fa' = 'en';

  setLanguage(lang: 'en' | 'fa'): void {
    this.currentLang = lang;
    document.documentElement.lang = lang; //change html lang
    document.documentElement.dir = lang === 'fa' ? 'rtl' : 'ltr'; // change html dir
  }

  getLanguage(): 'en' | 'fa' {
    return this.currentLang;
  }
}
