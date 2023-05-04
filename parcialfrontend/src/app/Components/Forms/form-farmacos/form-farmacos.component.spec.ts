import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormFarmacosComponent } from './form-farmacos.component';

describe('FormFarmacosComponent', () => {
  let component: FormFarmacosComponent;
  let fixture: ComponentFixture<FormFarmacosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormFarmacosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormFarmacosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
