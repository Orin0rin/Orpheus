import {Component} from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {NgIf, NgFor} from '@angular/common';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatTreeModule} from '@angular/material/tree';
import {MatIconModule} from '@angular/material/icon';
import {FormsModule} from '@angular/forms';
import {MatCheckboxModule} from '@angular/material/checkbox';


@Component({
  selector: 'sidebar',
  templateUrl: 'sidebar.component.html',
  styleUrls: ['sidebar.component.scss'],
  standalone: true,
  imports: [MatSidenavModule, NgIf, MatButtonModule, MatTreeModule, MatIconModule, MatCheckboxModule, FormsModule, NgFor],
})

export class SidebarComponent {
  showFiller = false;

  constructor() {

  }
}
