import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoEstilos } from './listado-estilos';

describe('ListadoEstilos', () => {
  let component: ListadoEstilos;
  let fixture: ComponentFixture<ListadoEstilos>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListadoEstilos]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListadoEstilos);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
