using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BUS
{
    /// <summary>
    /// Business layer for managing customer (KhachHang) operations
    /// Implements singleton pattern for centralized customer management
    /// </summary>
    public class KhachHangBUS
    {
        #region Singleton Pattern
        private static KhachHangBUS _instance;
        private static readonly object _lock = new object();

        /// <summary>
        /// Gets the singleton instance of KhachHangBUS
        /// Thread-safe implementation
        /// </summary>
        public static KhachHangBUS Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new KhachHangBUS();
                    }
                }
                return _instance;
            }
        }

        // Private constructor to prevent direct instantiation
        private KhachHangBUS() { }
        #endregion

        #region Public Methods

        /// <summary>
        /// Displays all customers in the provided DataGridView
        /// </summary>
        /// <param name="dataGridView">DataGridView control to display data</param>
        /// <exception cref="ArgumentNullException">Thrown when dataGridView is null</exception>
        public void ShowAllCustomers(DataGridView dataGridView)
        {
            if (dataGridView == null)
                throw new ArgumentNullException(nameof(dataGridView));

            try
            {
                var customers = DAO.KhachHangDAO.Instance.GetKhachhangs();
                var displayData = customers.Select(customer => new
                {
                    Id = customer.id_khachhang,
                    Name = customer.ten,
                    Email = customer.email,
                    Password = customer.matkhau,
                    PhoneNumber = customer.sodienthoai,
                    Address = customer.diachi,
                    CreatedDate = customer.ngaytao,
                    UpdatedDate = customer.ngaycapnhat
                });

                dataGridView.DataSource = displayData.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Updates an existing customer's information
        /// </summary>
        /// <param name="customerId">Customer ID to update</param>
        /// <param name="name">Customer name</param>
        /// <param name="email">Customer email</param>
        /// <param name="password">Customer password</param>
        /// <param name="phoneNumber">Customer phone number</param>
        /// <param name="address">Customer address</param>
        /// <param name="createdDate">Original creation date</param>
        /// <returns>True if update successful, false otherwise</returns>
        public bool UpdateCustomer(int customerId, string name, string email, string password,
            string phoneNumber, string address, DateTime createdDate)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var customer = new DAO.khachhang
                {
                    id_khachhang = customerId,
                    ten = name?.Trim(),
                    email = email?.Trim(),
                    matkhau = password,
                    sodienthoai = phoneNumber?.Trim(),
                    diachi = address?.Trim(),
                    ngaytao = createdDate,
                    ngaycapnhat = DateTime.Now
                };

                return DAO.KhachHangDAO.Instance.suaKhachHang(customer);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating customer: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Adds a new customer to the system
        /// </summary>
        /// <param name="name">Customer name</param>
        /// <param name="email">Customer email</param>
        /// <param name="password">Customer password</param>
        /// <param name="phoneNumber">Customer phone number</param>
        /// <param name="address">Customer address</param>
        /// <returns>True if addition successful, false otherwise</returns>
        public bool AddCustomer(string name, string email, string password,
            string phoneNumber, string address)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var customer = new DAO.khachhang
                {
                    ten = name?.Trim(),
                    email = email?.Trim(),
                    matkhau = password,
                    sodienthoai = phoneNumber?.Trim(),
                    diachi = address?.Trim(),
                    ngaytao = DateTime.Now,
                    ngaycapnhat = DateTime.Now
                };

                return DAO.KhachHangDAO.Instance.themKhachHang(customer);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding customer: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Searches for a customer by phone number and displays the result
        /// </summary>
        /// <param name="dataGridView">DataGridView to display search results</param>
        /// <param name="phoneNumber">Phone number to search for</param>
        /// <returns>True if customer found, false otherwise</returns>
        public bool SearchCustomerByPhoneNumber(DataGridView dataGridView, string phoneNumber)
        {
            if (dataGridView == null)
                throw new ArgumentNullException(nameof(dataGridView));

            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            try
            {
                var customer = DAO.KhachHangDAO.Instance.findKhachHangbySDT(phoneNumber.Trim());
                if (customer != null)
                {
                    var searchResults = new List<DAO.khachhang> { customer };
                    ShowSearchResults(dataGridView, searchResults);
                    return true;
                }

                // Clear the grid if no results found
                dataGridView.DataSource = null;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching customer: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Displays search results in the provided DataGridView
        /// </summary>
        /// <param name="dataGridView">DataGridView control to display results</param>
        /// <param name="customers">List of customers to display</param>
        public void ShowSearchResults(DataGridView dataGridView, List<DAO.khachhang> customers)
        {
            if (dataGridView == null)
                throw new ArgumentNullException(nameof(dataGridView));

            if (customers == null || !customers.Any())
            {
                dataGridView.DataSource = null;
                return;
            }

            try
            {
                var displayData = customers.Select(customer => new
                {
                    Id = customer.id_khachhang,
                    Name = customer.ten,
                    Email = customer.email,
                    Password = customer.matkhau,
                    PhoneNumber = customer.sodienthoai,
                    Address = customer.diachi,
                    CreatedDate = customer.ngaytao,
                    UpdatedDate = customer.ngaycapnhat
                });

                dataGridView.DataSource = displayData.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying search results: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}