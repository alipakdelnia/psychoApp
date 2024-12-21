import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UseresComponent } from './useres.component';

describe('UseresComponent', () => {
  let component: UseresComponent;
  let fixture: ComponentFixture<UseresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UseresComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UseresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
