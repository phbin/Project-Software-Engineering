using QuanLyCuaHangDaQuy.Model;
using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class Staff_ListServiceVM: BaseViewModel
    {
        public ObservableCollection<Service> ListService { get; set; } = new ObservableCollection<Service>();

        private Service _selectedService;
        public Service SelectedService
        {
            get { return _selectedService; }
            set { _selectedService = value; OnPropertyChanged(nameof(SelectedService)); }
        }
        public void LoadData()
        {
            ListService.Clear();
            var List = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.IDCusService == Staff_ListReceiptVM.IdReceipt);
            int no = 1;
            foreach (var item in List)
            {
                var DatTen = new Service
                {
                    No = no,
                    ID = item.ID,
                    IDService = item.IDService,
                    DateReturn_Format = item.DateReturn.ToShortDateString(),
                    DateReturn = item.DateReturn,
                    IDCusService = item.IDCusService,
                    Quantity = item.Quantity.ToString(),
                    Cost = item.Costs.ToString(),
                    Prepay = item.Prepay.ToString(),
                    PriceDiscounted = item.PriceDiscounted.ToString(),
                    Remain = item.Remain.ToString(),
                    Stt = item.Stt,
                    Total = item.Total.ToString(),
                    NameService = DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == item.IDService).FirstOrDefault().NameService,
                    ColorStt = (item.Stt == "unfinished") ? "#BCBCBC" : "#2CC33B",
                };
                ListService.Add(DatTen);
                no++;
            }

        }

     
        public ICommand LoadCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public Staff_ListServiceVM()
        {
            LoadCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) =>
                {
                    //Staff_ListReceiptVM.=
                    var List = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h=>h.IDCusService== Staff_ListReceiptVM.IdReceipt);
                    int no = 1;
                    foreach (var item in List)
                    {
                        var DatTen = new Service
                        {
                            No = no,
                            ID = item.ID,
                            IDService = item.IDService,
                            DateReturn_Format = item.DateReturn.ToShortDateString(),
                            DateReturn = item.DateReturn,
                            IDCusService = item.IDCusService,
                            Quantity = item.Quantity.ToString(),
                            Cost = item.Costs.ToString(),
                            Prepay = item.Prepay.ToString(),
                            PriceDiscounted = item.PriceDiscounted.ToString(),
                            Remain = item.Remain.ToString(),
                            Stt = item.Stt,
                            Total = item.Total.ToString(),
                            NameService = DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == item.IDService).FirstOrDefault().NameService,
                            ColorStt = (item.Stt == "unfinished") ? "#BCBCBC" : "#2CC33B",
                        };
                        ListService.Add(DatTen);
                        no++;
                    }
                }
            );
            AddCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) =>
                {
                    Staff_AddService staff_AddService = new Staff_AddService();
                    staff_AddService.ShowDialog();
                }
            );
            Service.EditCommand = new RelayCommand<object>(
               (p) => { return true; },
               (p) =>
               {
                   Staff_EditService staff_EditService = new Staff_EditService();   
                   staff_EditService.ShowDialog();
               }
           );
            Service.DeleteCommand = new RelayCommand<object>(
                           (p) => { return true; },
                           (p) =>
                           {
                               DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this receipt?", "", (MessageBoxButtons)MessageBoxButton.YesNo);
                               if (result == System.Windows.Forms.DialogResult.Yes)
                               {
                                   DataProvider.Ins.DB.SERVICELISTs.Remove(DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == SelectedService.ID).FirstOrDefault());
                                   DataProvider.Ins.DB.SaveChanges();
                                   var List = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.IDCusService == Staff_ListReceiptVM.IdReceipt);
                                   foreach (var item in List)
                                   {
                                       if (item.Stt == "unfinished")
                                       {
                                           LoadData();
                                           return;
                                       }
                                   }
                                   DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h => h.ID == Staff_ListReceiptVM.IdReceipt).FirstOrDefault().Stt = "finished";
                                   DataProvider.Ins.DB.SaveChanges();
                                   LoadData();
                               }
                           }
                       );
            Service.SttCommand = new RelayCommand<object>(
                          (p) => { return true; },
                          (p) =>
                          {
                              if(SelectedService.Stt == "unfinished")
                              {
                                  DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == SelectedService.ID).FirstOrDefault().Stt = "finished";
                                  DataProvider.Ins.DB.SaveChanges();
                                  var List = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.IDCusService == Staff_ListReceiptVM.IdReceipt);
                                  foreach ( var item in List)
                                  {
                                      if(item.Stt== "unfinished")
                                      {
                                          LoadData();
                                          return;
                                      }    
                                  }
                                  DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h => h.ID == Staff_ListReceiptVM.IdReceipt).FirstOrDefault().Stt= "finished";
                                  DataProvider.Ins.DB.SaveChanges();
                                  LoadData();
                                  return;
                              }  
                              else
                              {
                                  DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == SelectedService.ID).FirstOrDefault().Stt = "unfinished";
                                  DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h => h.ID == Staff_ListReceiptVM.IdReceipt).FirstOrDefault().Stt = "unfinished";
                                  DataProvider.Ins.DB.SaveChanges();
                                  LoadData();
                                  return;
                              }    
                          }
                      );


        }
    }
}
