import { Component } from '@angular/core';
import { LoadingService } from './Services/LoadingService';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Urwave';
  constructor(public loadingService: LoadingService) {}
}
