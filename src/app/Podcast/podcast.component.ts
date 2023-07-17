import { HttpClient } from '@angular/common/http';
import { Component, TemplateRef, ViewChild , AfterViewInit, OnInit} from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';
import { CellClickedEvent, ColDef, GridReadyEvent } from 'ag-grid-community';
import { PodcastService } from './podcast.service';
import { PodcastChild } from './podcast-child.component';
import { PodcastDto } from './podcast.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import 'jquery-datetimepicker';
import 'bootstrap';
import 'bootstrap-datetime-picker';
import './jquery.datetimepicker.d.ts';
import Swal from 'sweetalert2';
import { CookieService } from 'ngx-cookie-service';








@Component({
 selector: 'podcast',
 templateUrl: './podcast.component.html',
 styleUrls: ['../../styles.scss']
})




export class PodcastComponent implements OnInit {

  originalPublishDate: string | undefined;
  @ViewChild('addEditModalContent')
	addEditModalContent: TemplateRef<any> | any;

  truncateTextRenderer(params: { value: string; }) {
    const maxLength = 10; // Change this to the desired length
    const text = params.value || '';
    const truncatedText = text.substring(0, maxLength);
    return truncatedText;
  }

 public columnDefs: ColDef[] = [
   { field: 'id', width: 80, hide:true},
   { field: 'title',width:110 },
   { field: 'publishDate',width:140, cellRenderer: this.truncateTextRenderer },
   { field: 'description',width:200},
   { field: 'podcastGroupName',width:200},
   { field: 'buttons',
     cellRenderer: 'childMessageRenderer',
     headerName: 'buttons',
     colId: 'params',
   }
 ];
 public currentItem: PodcastDto | any;
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
 podcastGroups: any;
 podcast: PodcastDto | undefined;
 // For accessing the Grid's API
 @ViewChild(AgGridAngular) agGrid!: AgGridAngular;
 constructor(private http: HttpClient, private podcastSrv: PodcastService, private modal: NgbModal) {
  this.context={componentParent: this};
  this.frameworkComponents ={
    childMessageRenderer:PodcastChild,
  };
 }

 ngOnInit()
{
  this.podcastSrv.getAllPodcastGroups().subscribe(result=>this.podcastGroups=result);
}
reload() {

  this.podcastSrv.getAllPodcasts().subscribe((rec: any) => {
this.onGridReady(rec);
  });
}

 // Example load data from server
 onGridReady(params: GridReadyEvent) {

  this.podcastSrv.getAllPodcasts().subscribe((rec: any) => {this.rowData$ = rec.list;});

}


 // Example of consuming Grid Event
 onCellClicked( e: CellClickedEvent): void {
   console.log('cellClicked', e);
 }

CloseModal()
{
  this.modal.dismissAll();
}
showDelete( podcast :PodcastDto)
{
  Swal.fire({
    title: 'Are you sure?',
    text: 'This podcast will be deleted forever!',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Delete',
    cancelButtonText: 'Cancel'
  }).then((result) => {
    if (result.value) {
      this.podcastSrv.deletePodcast(podcast.id).subscribe(() => {
      this.reload();
    });
    this.reload();
      Swal.fire(
        'Delete',
        'The operation has done successfully',
        'success'
      )
    } else if (result.dismiss === Swal.DismissReason.cancel) {
      Swal.fire(
        'Cancel',
        'The operation was cancelled.',
        'error'
      )
    }
  })
}
ShowAddEditModal(item: PodcastDto|any)
{
  this.podcastSrv.selectPodcast(item);
  this.currentItem = new PodcastDto();
  this.modal.open(this.addEditModalContent, { size: 'sm' });
  if (item)
  {
    this.podcastSrv.podcastSelected.subscribe(podcast => this.currentItem = podcast);
  }
}
AddPodcast(){
  this.currentItem.publishDate = new Date().toISOString();
  this.originalPublishDate = this.currentItem.publishDate;
  this.podcastSrv.AddPodcast(this.currentItem);
  this.CloseModal();
  this.reload();
}

EditPodcast(currentItem: any)
{   this.currentItem.publishDate = new Date().toISOString();
  this.podcastSrv.EditPodcast(this.currentItem);
  this.CloseModal();
  this.reload();
}


 title="June11 HELLO";
}
