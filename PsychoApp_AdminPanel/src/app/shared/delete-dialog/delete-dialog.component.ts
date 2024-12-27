import { NgIf } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'app-delete-dialog',
  standalone: true,
  imports: [NgIf,TranslatePipe],
  templateUrl: './delete-dialog.component.html',
  styleUrl: './delete-dialog.component.css'
})
export class DeleteDialogComponent {
  @Input() title: string = 'CONFIRM_ACTION';
  @Input() message: string = 'ARE_YOU_SURE_YOU_WANT_TO_PERFORM_THIS_ACTION';
  @Input() confirmText: string = 'YES';
  @Input() cancelText: string = 'NO';
  @Input() isVisible: boolean = false;

  @Output() onConfirm = new EventEmitter<void>();
  @Output() onCancel = new EventEmitter<void>();

  confirm() {
    this.onConfirm.emit();
    this.isVisible = false;
  }

  cancel() {
    this.onCancel.emit();
    this.isVisible = false;
  }
}
