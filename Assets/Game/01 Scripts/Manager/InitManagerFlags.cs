public enum InitManagerFlags
{
    None = 0,
    Audio = 1 << 0,
    Vibration = 1 << 1,
    // Thêm các manager khác ở đây
    All = ~0  // Tất cả các bit đều được bật
}
