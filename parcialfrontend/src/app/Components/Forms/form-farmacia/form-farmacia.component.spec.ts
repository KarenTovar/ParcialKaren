import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormFarmaciaComponent } from './form-farmacia.component';

describe('FormFarmaciaComponent', () => {
  let component: FormFarmaciaComponent;
  let fixture: ComponentFixture<FormFarmaciaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormFarmaciaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormFarmaciaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
