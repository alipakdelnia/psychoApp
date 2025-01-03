import { Component } from '@angular/core';
import { MainServiceService } from '../../services/main-service.service';

@Component({
  selector: 'app-all-notes',
  standalone: true,
  imports: [],
  templateUrl: './all-notes.component.html',
  styleUrl: './all-notes.component.css'
})
export class AllNotesComponent {
notes: any;


  constructor (private mianService : MainServiceService){}

  getNotes() {
    this.mianService.getNotes().subscribe(
        (response: any[]) => {
            console.log(response);
            this.notes = response;
        },
        (error: any) => {
            console.error(error);
        },
        () => {
            console.log('All notes retrieved.');
        }
    );
}

}
