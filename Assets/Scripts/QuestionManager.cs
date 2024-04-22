using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance { get; private set; }
    public List<string> questions;
    public Dictionary<int, string> answers;

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }
    private void Start()
    {
        questions.Add("Đâu là một loại hình chợ tạm tự phát thường xuất hiện trong các khu dân cư?"); //1
        questions.Add("Đâu là tên một bãi biển ở Quảng Bình?"); //2
        questions.Add("Haiku là thể thơ truyền thống của nước nào?"); //3
        questions.Add("Chiến trường Đắk Tô - Tân Cảnh, nơi diễn ra chiến thắng vang đội năm 1972, nay thuộc địa bàn tỉnh nào ở Tây Nguyên?");
        questions.Add("Đâu là tên một loại bánh Huế?"); //5
        questions.Add("Tượng đài Chiến thắng Điện Biên Phủ được dựng trên ngọn đồi nào?"); //6
        questions.Add("Màu chủ đạo của tờ tiền Polymer mệnh giá 500.000 đồng là gì?"); //7
        questions.Add("Bảo tàng Hồ Chí Minh được thiết kế theo dáng một loài hoa nào?"); //8
        questions.Add("Tháng âm lịch nào còn được gọi là \"Tháng cô hồn\"?"); //9
        questions.Add("Có câu thành ngữ: \"Đi mây về ...\" gì?"); //10
        questions.Add("Đâu là một cách nói ví von về những trường hợp hay gặp vận hạn, rủi ro?"); //11
        questions.Add("Gỗ mun có màu gì?"); //12
        questions.Add("Tân Tổng thống Ukraine Volodymyr Zelensky làm nghề gì trước khi nhậm chức?"); //13
        questions.Add("Tình cảnh đơn độc, yếu thế không có chỗ dựa là nghĩa của câu nào?"); //14
        questions.Add("Đâu là tên một loại đồ chơi dân gian của trẻ em?"); //15
        questions.Add("Đâu không phải là một tác phẩm của họa sĩ Trần Văn Cẩn?"); //16
        questions.Add("Nhạc sĩ nào là người sáng tác ca khúc \"Cây đàn sinh viên\"?"); //17
        questions.Add("Nhà văn Kim Dung (Trung Quốc) nổi tiếng với thể loại văn học gì?"); //18
        questions.Add("Bộ phim \"Chị Dậu\" được chuyển thể từ tác phẩm nào?"); //19
        questions.Add("Cho tới thời điểm hiện nay, vườn quốc gia nào của nước ta chưa được công nhận là Vườn Di sản ASEAN?"); //20
        questions.Add("Hoa hậu Hòa bình Quốc tế 2017 dự kiến sẽ được tổ chức tại quốc gia nào?"); //21
        questions.Add("Loại cá nào bé hơn cả?"); //22
        questions.Add("Giọng khàn khàn còn được ví với gì?"); //23
        questions.Add("Sầu riêng Cái Mơn là đặc sản của tỉnh nào?"); //24
        questions.Add("Loại củ nào sau đây có thể giúp cho vết thương mau lành và ít để lại sẹo?"); //25


        answers = new Dictionary<int, string>();

        answers.Add(0, "Cóc/Ếch/Thằn lằn/Nhái");
        answers.Add(1, "Đá Nhảy/Đá Lăn/Đá Chạy/Đá Bò");
        answers.Add(2, "Nhật Bản/Mông Cổ/Trung Quốc/Hàn Quốc");
        answers.Add(3, "Kon Tum/Đắk Lắk/Gia Lai/Đắk Nông");
        answers.Add(4, "Khoái/Sướng/Thích/Vui");
        answers.Add(5, "D1/C1/A1/E1");
        answers.Add(6, "Xanh/Đỏ/Vàng/Tím");
        answers.Add(7, "Hoa sen/Hoa hướng dương/Hoa hồng/Hoa đào");
        answers.Add(8, "Tháng bảy/Tháng tám/Tháng chín/Tháng mười");
        answers.Add(9, "Gió/Mây/Núi/Biển");
        answers.Add(10, "Sao quả tạ/Sao quả cân/Sao quả yến/Sao quả tấn");
        answers.Add(11, "Đen/Vàng/Nâu/Xanh");
        answers.Add(12, "Diễn viên hài/Võ sĩ quyền anh/Bác sĩ phẫu thuật/Doanh nhân");
        answers.Add(13, "Thân cô thế cô/Thân lừa ưa nặng/Thân tàn ma dại/Thân làm tội đời");
        answers.Add(14, "Tò he/Tò mò/Tò vò/Tến tò");
        answers.Add(15, "Đôi bạn/Mẹ/Em Thúy/Em gái tôi");
        answers.Add(16, "Quốc An/Bảo Chấn/Trịnh Công Sơn/Trần Tiến");
        answers.Add(17, "Tiểu thuyết kiếm hiệp/Truyện trinh thám/Sử thi/Thơ lãng mạn");
        answers.Add(18, "Tắt đèn/Người mẹ cầm súng/Vợ chồng A Phủ/Tuổi thơ dữ dội");
        answers.Add(19, "Vườn quốc gia Tam Đảo/Vườn quốc gia Kon Ka Kinh/Vườn quốc gia Chư Mom Ray/Vườn quốc gia Bái Tử Long");
        answers.Add(20, "Việt Nam/Thái Lan/Lào/Campuchia");
        answers.Add(21, "Bống/Voi/Mập/Heo");
        answers.Add(22, "Vịt đực/Thiên nga/Ngan xiêm/Ngỗng");
        answers.Add(23, "Bến Tre/Tiền Giang/Cà Mau/Đồng Tháp");
        answers.Add(24, "Nghệ/Giềng/Hành tây/Gừng");
    }
    
    void Update()
    {
        
    }
}
