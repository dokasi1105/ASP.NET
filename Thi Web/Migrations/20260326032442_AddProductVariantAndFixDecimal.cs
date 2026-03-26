using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thi_Web.Migrations
{
    /// <inheritdoc />
    public partial class AddProductVariantAndFixDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://2tmobile.com/wp-content/uploads/2024/08/asus-rog-strix-g16-2024-g614-2tmobile.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://cdn.tgdd.vn/Products/Images/44/314837/dell-xps-15-9530-i7-71015716-thumb-600x600.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://cdn2.fptshop.com.vn/unsafe/1920x0/filters:format(webp):quality(75)/2024_2_16_638436790518626265_macbook-pro-14-2023-m3-pro-max-den%20(1).jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/laptop-lenovo-thinkpad-x1-gen-12-21kc008nvn-02.jpg?v=1732531914903");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://hanoicomputercdn.com/media/product/84656_laptop_hp_spectre_x360_14_eu0051tu__a2nl3pa___2_.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://hanoicomputercdn.com/media/product/74895_laptop_acer_gaming_nitro_16_phoenix_an16_41_r50z__nh_qlksv_001___1_.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTBlp9sfbMVTiWQPh6IG7zyUx0qTOUPbIqviQ&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/l/a/laptop-asus-zenbook-14-oled-ux3405ma-pp152w-3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://lapvip.vn/upload/products/original/razer-blade-16-2024-1710757551.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://anphat.com.vn/media/product/48813_17.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://lapvip.vn/upload/products/original/samsung-galaxy-book4-pro-360-16-2024-1711965445.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/grande/100/329/122/products/chuot-gaming-khong-day-logitech-g-pro-x-superlight-2-d9fa496b-1eb8-49e5-a9a1-4c275aa234a3.jpg?v=1741142613607");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/chuot-gaming-khong-day-razer-deathadder-v3-pro-7.jpg?v=1767322699743");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000722513/product/_q100_crop-fit_optimize_subsampling-2_36b24c7c9351454b988c38bf55e36b1b_8b41cbe6c65541ec84f85186542b9c3e.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000722513/product/mx-master-3s-mouse-top-view-graphite_880f7c80882541c2b4e349b7ed0fa439_de0fb8d222ec49bfb11d909a1f116f7e.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "https://gearshop.vn/upload/resizer.php?src=/upload/images/Product/Zowie/CHU%E1%BB%98T/EC3-CW/ZOWIE-EC2-cw-(1).JPG&w=800&h=800&q=72&zc=2");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000637319/product/ezgif-3-82221cec1f_d5437d20e2d243baac6a0ca726705ca5_master.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "https://cdnv2.tgdd.vn/mwg-static/tgdd/Products/Images/86/332191/chuot-apple-magic-mouse-usb-c-trang-2-638677956759654977-750x500.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000722513/product/thumbchuot-recovered_757cce0149c042149f8b58f30fcb3307_8868cbe7339a46e9813f2eb8bdb334ee.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000722513/product/g502x-plus-gallery-2-white_69229c9ba5534ad5bfae7d827037a28f_365394a31b6342e4949249099adb755e_master.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/chuot-gaming-khong-day-corsair-m75-air-ch-931d100-ap-5.jpg?v=1730307642997");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/ban-phim-co-khong-day-keychron-q1-pro-carbon-black-rgb-knob-hotswap-keychron-k-pro-switch-3.jpg?v=1706719750593");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImageUrl",
                value: "https://owlgaming.vn/wp-content/uploads/2024/01/ban-phim-co-ducky-one-3-cosmic-blue-sf-65.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/grande/100/329/122/products/ban-phim-co-khong-day-logitech-g915-x-lightspeed-tkl-07.jpg?v=1727148060207");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000722513/product/phim_6c19f3491c624a93acecf707c68a9cd8_137391e150d54883a044e69479533a20_84db1b13d01a4a5887432c33da001df9.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000722513/product/thumbphim-recovered-recovered_267e97e1955a416ebc59d2aabcdf227e_943e2216bceb4b11904c6249de9c260a.gif");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "ImageUrl",
                value: "https://pcmarket.vn/media/product/6962_leopold_fc900rc_egbpd_lbox_800x800_fefefe.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "ImageUrl",
                value: "https://cdn2.cellphones.com.vn/x/media/catalog/product/b/a/ban-phim-apple-magic-keyboard-touch-id-2021-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "ImageUrl",
                value: "https://imagor.owtg.one/unsafe/fit-in/800x800/https://d28jzcg6y4v9j1.cloudfront.net/media/core/products/2024/1/12/ban-phim-co-nuphy-air75-v2-qmkvia-thinkpro-nicespace-OMe.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImageUrl",
                value: "https://wooting-website.ams3.cdn.digitaloceanspaces.com/products/keyboards/60HE/60HE_OG.webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "ImageUrl",
                value: "https://azaudio.vn/wp-content/uploads/2024/10/steelseries-apex-pro-tkl-wireless-gen3-2024-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000722513/product/mnt-27gp850-gallery-04_57090512e4fb42de84bfa6adae25fbc0_652629fef6d94187b64adcf2214feacb_master.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTECPlrTgI0ra_JLCn9dybbIpX3CfpbqLIskQ&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTqzji31Gw5mFbChp54R0rK9tC2FA9obH5jDA&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSnlHv2p4Jrm8g1XIkGyC496YfQ_tYdOD1U4A&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/man-hinh-2k-benq-27-inch-ips-144hz-benq-ex2780q-4.png?v=1633663195497");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRogRnwSVtN-tEuw8XzzFkw4N2tOn4zIYXMLQ&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "ImageUrl",
                value: "https://product.hstatic.net/1000333506/product/msi_mag274qrf_qd_gearvn_66dcd66a1bab4d8a8a9742be876a97a5_376dce3f245142e7bee4b73bb22b6a04.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000420363/product/man-hinh-gaming-lg-45gr95qe-b.atv-7_2ed757535246423b8d193e1ce6c55dd6_master.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "ImageUrl",
                value: "https://product.hstatic.net/1000333506/product/-240hz-1ms-hdr400-chuyen-game-2_a9485e1eb61540e0be158de0e1438f31_large_cc6318cde73245daaadf72972ca248a8.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000722513/product/man-hinh-asus-proart-pa248crv-24-inch-1.png_f5f89eeec36f4ca98e12a1b4fae08ace_master.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/100/329/122/products/vga-gigabyte-geforce-rtx-4070-ti-super-gaming-oc-16g-gddr6x.jpg?v=1743639363470");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "ImageUrl",
                value: "https://nguyencongpc.vn/media/product/24427-cpu-amd-ryzen-9-7950x3d.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "ImageUrl",
                value: "https://hanoicomputercdn.com/media/product/83745_cpu_intel_core_i9_14900ks_up_to_6_2ghz_24_nhan_32_luong_36mb_cache_125w_socket_intel_lga_1700_raptor_lake.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/grande/100/329/122/products/ram-pc-corsair-vengeance-rgb-64gb-6000mhz-ddr5-2x32gb-cmh64gx5m2d6000c40-01.jpg?v=1759114857510");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/ssd-samsung-990-pro-pcie-gen-4-0-x4-nvme-v-nand-m-2-2280-1tb-mz-v9p1t0bw-2-0e7ba42e-7ddc-4be9-8415-12a33d609067.jpg?v=1661577087873");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT9ycJT2BLgmVktCDTju07N11tvWIBWjkz5bA&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/grande/100/329/122/products/nguon-may-tinh-corsair-rm1000x-shift-1000w-80-plus-gold-cp-9020253-na.jpg?v=1758522543577");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/tan-nhiet-khi-noctua-nh-d15-chromax-black-nh-d15-chromax-black-1.jpg?v=1680255731507");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "ImageUrl",
                value: "https://nguyencongpc.vn/media/product/24039-24gb-gddr624gb-gddr624gb-gddr6.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000722513/product/z51_5fd17076678d4f5b8bdb7d1d9833c578_d741c129305e401aa8e9f1740c10a5d4.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2ZkasOuaFwbP4nVfmQGu3li1VwMSVaxcZrQ&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRiaX2_-TxCRX7NW_Meft2MQIz5LzgQmfmVog&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrlw5BRMj_JjOz9ansvdIWI6c_qhupBhkv2g&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "ImageUrl",
                value: "https://cdn.tgdd.vn/Products/Images/54/315014/tai-nghe-bluetooth-airpods-pro-2nd-gen-usb-c-charge-apple-1-750x500.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "ImageUrl",
                value: "https://www.tncstore.vn/media/product/9068-tai-nghe-logitech-g-pro-x-2-light-speed-wireless-black-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRYyWb_ibwSyoXT9KVra20AclwyCZKiHlZpAQ&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "ImageUrl",
                value: "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/t/a/tai-nghe-samsung-galaxy-buds-3-pro_8_.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/1024x1024/100/451/485/products/jbl-quantum-910-1.jpg?v=1662366706857");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQi2gXKqNpaPILYBnL5POSvzrVd2F3Vi8kBxg&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/wd-black-sn850x-2tb-3d-hr.jpg?v=1741160387027");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/100/329/122/products/seagate-barracuda-3-5-4tb-1.jpg?v=1638370587313");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "ImageUrl",
                value: "https://lagihitech.vn/wp-content/uploads/2023/08/SSD-Crucial-T700-2TB-M2-PCIe-Gen-5.0-CT2000T700SSD3-hinh-3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "ImageUrl",
                value: "https://npp.com.vn/wp-content/uploads/2023/06/ST20000NT001.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000320233/product/1696736456-908-o-cung-di-dong-ssd-portable-1tb-samsung-t9-mau-den-6_533557ae3e164a77aa8e2aa8326a5013_1024x1024.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "ImageUrl",
                value: "https://tandoanh.vn/wp-content/uploads/2022/11/Kingston-KC3000-H1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "ImageUrl",
                value: "https://western.com.vn/media/product/136_o_cung_wd_blue_1tb_wd10spzx_cho_laptop.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "ImageUrl",
                value: "https://bizweb.dktcdn.net/thumb/grande/100/410/941/products/12-a45f3025-8e41-4640-9854-02f9b96f4840.jpg?v=1678674691927");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "ImageUrl",
                value: "https://www.winwinstore.vn/wp-content/uploads/2025/08/4-the-nho-sd-lexar-64gb-professional-1800x-uhs-ii-v60.webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "ImageUrl",
                value: "https://tuanphong.vn/pictures/full/2021/05/1621500196-331-o-cung-ssd-m2-pcie-1tb-sabrent-rocket-4-plus-nvme-2280-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "ImageUrl",
                value: "https://images-na.ssl-images-amazon.com/images/I/410uYasNqFL.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "ImageUrl",
                value: "https://tanthanhdanh.vn/wp-content/uploads/2022/01/Herman-Miller-X-Logitech-G-Embody-Gaming-Chair-Cyan-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/61ANYzz96+L._AC_UF894,1000_QL80_.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "ImageUrl",
                value: "https://product.hstatic.net/1000333506/product/noblechairs-hero-series-gaming-chair-black-1_9636fe3c9a6241e5808dec863984f606_1024x1024.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS32mTNUqtmAETVwJe1HhKOdu_i6Apz_St-iQ&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "ImageUrl",
                value: "https://nguyencongpc.vn/media/product/23944-corsair-tc200-leatherette-light-grey-white.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000722513/product/ghe-gaming-razer-iskur-v2-rz38-0_0878920999844332a0cd6435d6cc6eaa.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "ImageUrl",
                value: "https://xiaomistoreph.com/cdn/shop/products/Hbada_ChairE301BLA_WBG_2_1000x1000.jpg?v=1749553078");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "ImageUrl",
                value: "https://cdn2.cellphones.com.vn/x/media/catalog/product/p/h/photo_2024-10-02_13-59-00_1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "ImageUrl",
                value: "https://cdn.tgdd.vn/Products/Images/42/281570/iphone-15-xanh-thumb-600x600.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "ImageUrl",
                value: "https://cdn2.fptshop.com.vn/unsafe/512x0/filters:format(webp):quality(75)/galaxy_s25_ultra_titan_silver_blue_2_85ef2eff39.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "ImageUrl",
                value: "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/d/i/dien-thoai-samsung-galaxy-s25_27__2_1_2.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "ImageUrl",
                value: "https://product.hstatic.net/1000370129/product/cd246c789aa4695dbbda8af_master_5544aebb4580483ba363207b86b70537_master_71c0f27431f64b86b52bc23bf56d9460_master.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "ImageUrl",
                value: "https://viostore.vn/wp-content/uploads/2024/10/26.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "ImageUrl",
                value: "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/i/m/image_1262703570.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "ImageUrl",
                value: "https://www.xtmobile.vn/vnt_upload/product/06_2024/oppo-find-x8-pro-xtmobile.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "ImageUrl",
                value: "https://cdn-v3.xtmobile.vn/vnt_upload/product/05_2024/thumbs/600_samsung_galaxy_a55_5g_awesome_lemon_8_256gb_6_6_quot_amoled_120hz_full_hd_2.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "ImageUrl",
                value: "https://cdn.viettablet.com/images/thumbnails/480/516/detailed/52/apple-iphone-se-3-2022-chinh-hang_9szb-as.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "ImageUrl",
                value: "https://viostore.vn/wp-content/uploads/2024/10/2-9.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "ImageUrl",
                value: "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/d/i/dien-thoai-nothing-phone-2a-plus_1_.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "ImageUrl",
                value: "https://www.sieuthimaychu.vn/datafiles/setone/17586163099598.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "ImageUrl",
                value: "https://www.sieuthimaychu.vn/datafiles/setone/17586163099598.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "ImageUrl",
                value: "https://cdn-dynmedia-1.microsoft.com/is/image/microsoftcorp/PT_RGB_Windows11_Pro_EN_375x375");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "ImageUrl",
                value: "https://cdn.tgdd.vn/GameApp/3/235353/Screentshots/tai-adobe-creative-cloud-phan-mem-ho-tro-quan-ly-va-235353-logo-18-02-2021.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT0PjFAsBQtufK2kk5JIsWuvChlLDu8FPgtYw&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "ImageUrl",
                value: "https://i0.wp.com/software.centrix.asia/wp-content/uploads/2024/10/Midjourney-Basic-Plan.png?fit=1080%2C1080&ssl=1");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "ImageUrl",
                value: "https://images-eds-ssl.xboxlive.com/image?url=4rt9.lXDC4H_93laV1_eHHFT949fUipzkiFOBH3fAiZZUCdYojwUyX2aTonS1aIwMrx6NUIsHfUHSLzjGJFxxo4K81Ei7WzcnqEk8W.MgwbrV7KGaO26hIr2djuNhOO6._j8uCsDS5VM2l2zZ5lg_lA3NC6rF2454qkJTgncsPY-&format=source");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "ImageUrl",
                value: "https://i0.wp.com/software.centrix.asia/wp-content/uploads/2024/10/Grammarly.png?fit=1080%2C1080&ssl=1");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "ImageUrl",
                value: "https://digitalnext.co.uk/wp-content/uploads/2024/05/NordVPN-image.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://d28jzcg6y4v9j1.cloudfront.net/media/core/products/2024/1/10/asus-rog-strix-scar-g16-2024-undefined.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://nhatminhlaptop.com/upload/products/2023-03-23-13-45-56/9530-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://p1-ofp.static.pub/medias/bWFzdGVyfHJvb3R8MjQ2NjI5fGltYWdlL3BuZ3xoZTYvaGRkLzE0Mjc5NTM5MDYyNjE0LnBuZ3w0YjdiMzJjYmNhMzFkMGEzMGM0YzYxZDQ4OThhMzY5NGRhNjBhODA3YmFiMTBjODU1MzNhYzFiZDA3ZjY5YTAy/Lenovo-laptop-thinkpad-x1-carbon-gen-12-hero.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://ssl-product-images.www8-hp.com/digmedialib/prodimg/knowledgebase/c08586213.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://static-ecshop.acer.com/media/catalog/product/n/h/nh.qlfsv.00e_1_1.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://asset.msi.com/resize/image/global/product/product_16920631213e2f6d573ead3.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://dlcdnwebimgs.asus.com/gain/C43AECF2-D312-4BDA-B8D1-43BD8A2C3D99/w1000/h732");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://assets2.razerzone.com/images/pnx.assets/93f03d7a0bf8a50d7a8e8e2b2bc1e4a2/razer-blade-16-2024-500x500.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://www.lg.com/us/images/laptops/md08003753/gallery/large01.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://images.samsung.com/is/image/samsung/p6pim/vn/2401/gallery/vn-galaxy-book4-pro-360-np960qgk-kg1vn-thumb-539493745");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://resource.logitech.com/w_692,c_lpad,ar_4:3,q_auto,f_auto,dpr_1.0/d_transparent.gif/content/dam/gaming/en/products/pro-x-superlight-2/pro-x-superlight-2-gallery-1.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://assets2.razerzone.com/images/pnx.assets/07cf6e7eb0e7e8f55ad32e2b17d5d7c9/razer-deathadder-v3-pro-500x500.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://media.steelseriescdn.com/thumbs/catalogue/products/01806-aerox-5-wireless/5e9e1a4f1e6a4b3baa3c0e0e0e0e0e0e/aerox-5-wireless-pdp-hero.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "https://resource.logitech.com/w_692,c_lpad,ar_4:3,q_auto,f_auto,dpr_1.0/d_transparent.gif/content/dam/logitech/en/products/mice/mx-master-3s/gallery/mx-master-3s-mouse-top-view-graphite.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "https://zowie.benq.com/content/dam/zowie/products/mouse/ec2-cw/gallery/ec2-cw-front.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "https://www.pulsar.gg/cdn/shop/files/x2v2-white-hero.png?v=1706864731&width=1080");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/MMMQ3?wid=1144&hei=1144&fmt=jpeg&qlt=90&.v=1645138962000");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "https://assets2.razerzone.com/images/pnx.assets/c0d1ff37f06e07fecef4bb7a234a82e5/razer-basilisk-v3-pro-500x500.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "https://resource.logitech.com/w_692,c_lpad,ar_4:3,q_auto,f_auto,dpr_1.0/d_transparent.gif/content/dam/gaming/en/products/g502-x-plus/g502-x-plus-gallery-1-black.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImageUrl",
                value: "https://www.corsair.com/medias/sys_master/images/images/h72/hec/9476017373214/CH-931D010-NA-Gallery-M75-Air-Wireless-01.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImageUrl",
                value: "https://cdn.shopify.com/s/files/1/0059/0630/1017/files/Keychron-Q1-Pro-QMK-VIA-wireless-custom-mechanical-keyboard-1_1800x1800.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImageUrl",
                value: "https://www.duckychannel.com.tw/upload/images/keyboard/one3/one3-sf-matcha/2022_one3_sf_matcha_01.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "ImageUrl",
                value: "https://resource.logitech.com/w_692,c_lpad,ar_4:3,q_auto,f_auto,dpr_1.0/d_transparent.gif/content/dam/gaming/en/products/g915-tkl/gallery/g915-tkl-keyboard-top-view-black.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "ImageUrl",
                value: "https://assets2.razerzone.com/images/pnx.assets/ba8a3b1f68b26fae3dddca5dbb4b6840/razer-blackwidow-v4-pro-500x500.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "ImageUrl",
                value: "https://en.akkogear.com/wp-content/uploads/2021/08/Akko-3087-DS-Ocean-Star-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "ImageUrl",
                value: "https://mechanicalkeyboards.com/cdn/shop/products/fc900r-pd-white-blue_grande.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "ImageUrl",
                value: "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/MK293LL?wid=1144&hei=1144&fmt=jpeg&qlt=90&.v=1645138963000");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "ImageUrl",
                value: "https://cdn.shopify.com/s/files/1/0268/9673/3662/products/NuPhy-Air75-V2-Wireless-Mechanical-Keyboard-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImageUrl",
                value: "https://wooting.io/static/wooting-60he-plus-product-shot-b19f9d5f1a4e5a6d2c7b8e9f0a1b2c3d.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "ImageUrl",
                value: "https://media.steelseriescdn.com/thumbs/catalogue/products/01776-apex-pro-tkl-wireless/98ae37f8c8bc4c2d8c2d4e5f6a7b8c9d/apex-pro-tkl-wireless-pdp-hero.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "ImageUrl",
                value: "https://www.lg.com/us/images/monitors/md07521413/gallery/large01.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "ImageUrl",
                value: "https://image-us.samsung.com/SamsungUS/home/computing/monitors/gaming/05222020/lc32g75tqsnxza-gallery-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "ImageUrl",
                value: "https://dlcdnwebimgs.asus.com/gain/2BF2E66D-C5F9-4D6A-89FD-A5F7C8BC64B7/w1000/h732");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "ImageUrl",
                value: "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/peripherals/monitors/u-series/u2723de/media-gallery/monitor-u2723de-gallery-1.psd?fmt=png-alpha&pscan=auto&scl=1&hei=402&wid=402&qlt=100,1&resMode=sharp2&size=402,402&chrss=full");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "ImageUrl",
                value: "https://video.benq.com/is/image/benqco/EX2780Q_main?$ResponsiveImage$");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "ImageUrl",
                value: "https://static.acer.com/up/Resource/Acer/Monitors/Predator/Predator-X28/Specifications/20211101/X28-hero-image.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "ImageUrl",
                value: "https://asset.msi.com/resize/image/global/product/product_17006987161efe8b5e9df7e.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "ImageUrl",
                value: "https://www.lg.com/us/images/monitors/md08003253/gallery/large01.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "ImageUrl",
                value: "https://static.gigabyte.com/StaticFile/Image/Global/8cbcc5bb5ad84de20e9af62c9faf5c6e/Product/30133/png/1000");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "ImageUrl",
                value: "https://dlcdnwebimgs.asus.com/gain/CB02B60E-D4C9-4E7F-BD21-A3FA55F6F7B6/w1000/h732");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "ImageUrl",
                value: "https://www.nvidia.com/content/dam/en-zz/Solutions/geforce/ada/rtx-4070-ti-super/geforce-rtx-4070-ti-super-product-photo-003-webp.webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "ImageUrl",
                value: "https://www.amd.com/system/files/2023-02/7950x3d-PIB-angle.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "ImageUrl",
                value: "https://www.intel.com/content/dam/www/public/us/en/images/products/hero/14th-gen-core-desktop-processor-hero-badge-rwd.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "ImageUrl",
                value: "https://www.corsair.com/medias/sys_master/images/images/h44/hce/9501839073310/CMK32GX5M2B6000C36-Gallery-CMK32GX5M2B6000C36-1.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "ImageUrl",
                value: "https://image-us.samsung.com/SamsungUS/home/computing/memory-storage/ssd/07182022/MZ-V9P2T0B-galaxy-999.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "ImageUrl",
                value: "https://dlcdnwebimgs.asus.com/gain/EBD3A3E1-7437-4F91-A5A2-6B1C7ADE7EC6/w1000/h732");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "ImageUrl",
                value: "https://www.corsair.com/medias/sys_master/images/images/hcf/hae/9476017471518/CP-9020253-NA-Gallery-RM1000x-SHIFT-01.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "ImageUrl",
                value: "https://noctua.at/pub/media/catalog/product/cache/0d834e97c2d4c56a4cbf49b1dd48db85/n/h/nh-d15-chromax-black_1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "ImageUrl",
                value: "https://www.amd.com/system/files/2022-11/1013991-radeon-rx-7900-xt-xtx-product-photo.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "ImageUrl",
                value: "https://www.gskill.com/img/product/memory/20230210120753-zoom.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "ImageUrl",
                value: "https://media.steelseriescdn.com/thumbs/catalogue/products/01852-arctis-nova-pro-wireless/fba175af15594f5f9b51a37aac2e9e44/arctis-nova-pro-wireless-pdp-hero.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "ImageUrl",
                value: "https://hyperx.com/cdn/shop/products/HyperX-Cloud-Alpha-Wireless-Gaming-Headset-Hero.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "ImageUrl",
                value: "https://assets2.razerzone.com/images/pnx.assets/4a17a8c73e8f0c69b2b3e6ddd9e0b853/razer-blackshark-v2-pro-2023-500x500.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "ImageUrl",
                value: "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/MQTP3?wid=1144&hei=1144&fmt=jpeg&qlt=90&.v=1660803972000");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "ImageUrl",
                value: "https://resource.logitech.com/w_692,c_lpad,ar_4:3,q_auto,f_auto,dpr_1.0/d_transparent.gif/content/dam/gaming/en/products/g-pro-x-2/g-pro-x-2-gallery-1.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "ImageUrl",
                value: "https://www.beyerdynamic.com/media/catalog/product/cache/1/image/800x800/9df78eab33525d08d6e5fb8d27136e95/d/t/dt-990-pro-01.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "ImageUrl",
                value: "https://images.samsung.com/vn/smartphones/galaxy-buds3-pro/images/galaxy-buds3-pro-silver-detail-image-01.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "ImageUrl",
                value: "https://www.jbl.com/dw/image/v2/AAUJ_PRD/on/demandware.static/-/Sites-masterCatalog_Harman/default/dw3b3c3b3d/JBL_QUANTUM910_WIRELESS_IMAGE_HERO_BLK.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "ImageUrl",
                value: "https://assets.sennheiser.com/img/21630/x1_desktop_Sennheiser_HD599SE_03.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "ImageUrl",
                value: "https://shop.westerndigital.com/content/dam/store/en-us/assets/products/internal-gaming-drives/wd-black-sn850x-nvme-ssd/gallery/wd-black-sn850x-nvme-ssd-1tb-hero.png.thumb.1280.1280.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "ImageUrl",
                value: "https://www.seagate.com/www-content/product-content/barracuda-fam/barracuda-new/images/barracuda-3-5-ssd-2tb-400x400.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "ImageUrl",
                value: "https://www.crucial.com/content/dam/crucial/ssd-products/t700/images/in-box/crucial-t700-ssd-with-heatsink-in-box-image.psd.transform/medium-jpg/img.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "ImageUrl",
                value: "https://www.seagate.com/www-content/product-content/ironwolf-fam/ironwolf-pro/images/ironwolf-pro-14tb-400x400.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "ImageUrl",
                value: "https://image-us.samsung.com/SamsungUS/home/computing/memory-storage/portable-ssd/08032023/MU-PG4T0B-galaxy-999.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "ImageUrl",
                value: "https://www.kingston.com/dataSheets/SKC3000D2048G_en.pdf");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "ImageUrl",
                value: "https://shop.westerndigital.com/content/dam/store/en-us/assets/products/internal-pc-storage/wd-blue-mobile-hard-drive/gallery/wd-blue-mobile-hard-drive-500gb-2.5-7mm.png.thumb.1280.1280.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "ImageUrl",
                value: "https://www.silicon-power.com/web/images/product/SP_XD80_1.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "ImageUrl",
                value: "https://www.lexar.com/content/dam/lexar/products/cfexpress-cards/professional-1800x-cfexpress-type-b-card/gallery/lexar-cfexpress-type-b-256gb-1800x-product.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "ImageUrl",
                value: "https://sabrent.com/cdn/shop/products/SB-RKT4P-4TB-main.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "ImageUrl",
                value: "https://secretlab.co/cdn/shop/files/TITAN-Evo-2022-SoftWeave-Plus-Charcoal-Blue-Hero_1800x.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "ImageUrl",
                value: "https://www.hermanmiller.com/content/dam/hermanmiller/images/products/seating/embody/embody-gaming-chair-3q-black-tr-gr-az.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "ImageUrl",
                value: "https://www.dxracer.com/cdn/shop/files/Formula_Series_F08_Black_and_Red_001.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "ImageUrl",
                value: "https://noblechairs.com/cdn/shop/products/hero-series-gaming-chair-black-white.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "ImageUrl",
                value: "https://www.andaseat.com/cdn/shop/products/kaiser-4-xl-gaming-chair.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "ImageUrl",
                value: "https://www.corsair.com/medias/sys_master/images/images/ha9/h3b/9545432113182/CF-9010052-WW-Gallery-Corsair-T3-RUSH-Fabric-Gaming-Chair-Grey-Blue-01.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "ImageUrl",
                value: "https://assets2.razerzone.com/images/pnx.assets/0a1b2c3d4e5f6a7b8c9d0e1f2a3b4c5d/razer-iskur-v2-500x500.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "ImageUrl",
                value: "https://cdn.cnbj1.fds.api.mi-img.com/b2c-shopapi-pms/pms_1694677900.11358949.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "ImageUrl",
                value: "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone-16-pro-finish-select-202409-6-9inch-deserttitanium?wid=5120&hei=2880&fmt=p-jpg&qlt=80&.v=1725415431361");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "ImageUrl",
                value: "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone-15-finish-select-202309-6-1inch-pink?wid=5120&hei=2880&fmt=p-jpg&qlt=80&.v=1692982705895");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "ImageUrl",
                value: "https://images.samsung.com/vn/smartphones/galaxy-s25-ultra/images/galaxy-s25-ultra-titanium-blue-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "ImageUrl",
                value: "https://images.samsung.com/vn/smartphones/galaxy-s25-plus/images/galaxy-s25-plus-icyblue-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "ImageUrl",
                value: "https://lh3.googleusercontent.com/nu1BpvkpFDh1KI7oqKjhFjwOyV4H7q0RoAU0KWtTM34WvHf1vXVHHjAJ8VYr6A7LVHjQ7nT3HGw=rw-w820");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "ImageUrl",
                value: "https://image01.oneplus.net/ebp/202412/17/1-m00-53-e9-rb8bwwygczuatooxaap5c3cukzw967.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "ImageUrl",
                value: "https://i02.appmifile.com/mi-com-product/fly-birds/xiaomi-15-pro/m/3b90b51c0c0869ac55618bc1c5b84e95.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "ImageUrl",
                value: "https://image.oppo.com/content/dam/oppo/common/mkt/v2en/find-x8-pro/find-x8-pro-kv.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "ImageUrl",
                value: "https://images.samsung.com/vn/smartphones/galaxy-a55-5g/images/galaxy-a55-5g-awesome-icyblue-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "ImageUrl",
                value: "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone-se-finish-select-202203-6-1inch-midnight?wid=5120&hei=2880&fmt=p-jpg&qlt=80&.v=1646445666203");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "ImageUrl",
                value: "https://www.vivo.com/content/dam/vivo/en/products/x200-pro/blue.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "ImageUrl",
                value: "https://global-website-assets.nothing.tech/images/phone-2a-plus/phone-2a-plus-overview-01.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "ImageUrl",
                value: "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RE4OXeo?ver=6db3");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "ImageUrl",
                value: "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RE4OXeo?ver=6db3");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "ImageUrl",
                value: "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RWEHjV?ver=b5e6");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "ImageUrl",
                value: "https://www.adobe.com/content/dam/cc/icons/Creative_Cloud.svg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/Claude_AI_logo.svg/1200px-Claude_AI_logo.svg.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e6/Midjourney_Emblem.png/800px-Midjourney_Emblem.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bb/Canva_Logo.svg/1200px-Canva_Logo.svg.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6e/Grammarly_logo.svg/2560px-Grammarly_logo.svg.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/5/52/NordVPN_logo_monochromatic.svg/1280px-NordVPN_logo_monochromatic.svg.png");
        }
    }
}
