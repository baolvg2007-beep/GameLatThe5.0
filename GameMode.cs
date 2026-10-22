using System;

namespace game_lật_thẻ_1._1
{
    /// <summary>
    /// Định nghĩa Enum để phân biệt 2 chế độ chơi trong toàn bộ dự án
    /// </summary>
    public enum GameMode
    {
        MemoryMatch,     // Game 1: Lật thẻ ghép cặp trí nhớ
        SequentialOrder  // Game 2: Lật thẻ theo số tiến lên (1 -> N)
    }
}
