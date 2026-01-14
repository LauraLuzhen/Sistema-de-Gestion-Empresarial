import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { FormularioPersona } from './components/formulario-persona/formulario-persona';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TablaPersonas, FormularioPersona],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('TE QUIERO');
}
