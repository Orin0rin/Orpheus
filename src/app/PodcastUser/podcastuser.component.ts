import { HttpClient } from '@angular/common/http';
import { Component, TemplateRef, ViewChild, OnInit} from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';
import { ColDef, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { Observable } from 'rxjs';
import { PodcastUserService } from './podcastuser.service';
import { PodcastUserChild } from './podcastuser-child.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import 'bootstrap';
import { DomSanitizer } from '@angular/platform-browser';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'podcast',
  templateUrl: './podcastuser.component.html',
  styleUrls: ['../../styles.scss']
 })
 export class PodcastUserComponent implements OnInit {

  @ViewChild('addEditModalContent')
	addEditModalContent: TemplateRef<any> | any;
  truncateTextRenderer(params: { value: string; }) {
    const maxLength = 10; // Change this to the desired length
    const text = params.value || '';
    const truncatedText = text.substring(0, maxLength);
    return truncatedText;
  }

 public columnDefs: ColDef[] = [
   { field: 'title',width:110},
   { field: 'publishDate',width:240, editable:true, cellRenderer: this.truncateTextRenderer },
   { field: 'description',width:250},
   {
    headerName: 'Audio',
    field: 'voiceAddress',
    width:350,
    cellRenderer: (params: { value: any; }) => {
      const audio = document.createElement('audio');
      audio.setAttribute('controls', '');
      const source = document.createElement('source');
      source.setAttribute('src', params.value);
      source.setAttribute('type', 'audio/mpeg');
      audio.appendChild(source);
      return audio;
    }


  }
 ];

 public frameworkComponents;
 public context;
 // DefaultColDef sets props common to all Columns
 public defaultColDef: ColDef = {
   sortable: true,
   filter: true,
   resizable: true
 };

 // Data that gets displayed in the grid
 rowData$: any;
 public gridOptions: GridOptions;
 podcastGroups: any;
 // For accessing the Grid's API
 @ViewChild(AgGridAngular) agGrid!: AgGridAngular;
 constructor(private http: HttpClient, private podcastuserSrv: PodcastUserService, private modal: NgbModal, private sanitizer: DomSanitizer) {
  this.gridOptions = {
    // Set the getRowHeight function to always return 199
    getRowHeight: (params) => {
      return 500;
    },
    // Other grid options...
  };
  this.context={componentParent: this};
  this.frameworkComponents ={
    childMessageRenderer:PodcastUserChild,
  };
 }

 ngOnInit()
{
  this.podcastuserSrv.getAllPodcastGroups().subscribe(result=>this.podcastGroups=result);
}
reload() {

  this.podcastuserSrv.getAllPodcasts().subscribe((rec: any) => {
this.onGridReady(rec);
  });
}

 // Example load data from server
 onGridReady(params: GridReadyEvent) {

  this.podcastuserSrv.getAllPodcasts().subscribe((rec: any) => {this.rowData$ = rec.list;});
}



CloseModal()
{
  this.modal.dismissAll();
}



 title="Welcome User!";
}

