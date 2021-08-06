using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing;
using SM64MidiCompanion.Forms;


namespace SM64MidiCompanion.Components
{

    enum TrackColumn
    {
        Enabled,
        Channel,
        Name,
        Instrument,
        Pitch
    }

    class TrackListView : ListView
    {
        List<TrackInfo> tracks = new List<TrackInfo>();

        const int imageSize = 24;
        const int columnSize = 52;
        const int rowHeight = 32;

        Image checkedBox, unCheckedBox;

        public List<TrackInfo> Tracks
        {
            get
            {
                return tracks;
            }

            set
            {
                tracks = value;
                LoadMidiItems();
            }
        }

        public TrackListView()
        {
            OwnerDraw = true;
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, rowHeight);
            SmallImageList = imgList;
            checkedBox = (Image)(Properties.Resources.ResourceManager.GetObject("CheckedBox24"));
            unCheckedBox = (Image)(Properties.Resources.ResourceManager.GetObject("UnCheckedBox24"));
            FullRowSelect = true;
        }

        public void LoadMidiItems()
        {
            Items.Clear();
            foreach (TrackInfo track in tracks)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems[0].Text = track.enabled.ToString();
                item.SubItems.Add(track.channel.ToString());

                item.SubItems.Add(track.name.ToString());
                if (track.instrumentId >= 0)
                {
                    item.SubItems.Add(track.instrumentId.ToString());
                }
                else
                {
                    item.SubItems.Add("No inst.");
                }
                item.SubItems.Add(track.pitchShiftId.ToString());

                Items.Add(item);
            }
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            if (tracks == null || tracks.Count == 0)
            {
                return;
            }

            ListViewHitTestInfo hitTestInfo = GetHitInfo();
            int columnIndex = GetColumnIndexFromHit(hitTestInfo);
            int itemIndex = hitTestInfo.Item.Index;

            switch ((TrackColumn)columnIndex)
            {
                case TrackColumn.Enabled:
                    tracks[itemIndex].enabled = !tracks[itemIndex].enabled;
                    break;
                case TrackColumn.Instrument:
                    UpdateTrackInstrument(itemIndex);
                    break;
                case TrackColumn.Pitch:
                    UpdateTrackPitchShift(itemIndex);
                    break;
                case TrackColumn.Channel:
                    UpdateTrackChannel(itemIndex);
                    break;
                default:
                    break;
            }

            LoadMidiItems();
        }

        protected override void OnClick(EventArgs e)
        {
            ListViewHitTestInfo hitTestInfo = GetHitInfo();
            int columnIndex = GetColumnIndexFromHit(hitTestInfo);
            int itemIndex = hitTestInfo.Item.Index;

            switch ((TrackColumn)columnIndex)
            {
                case TrackColumn.Enabled:
                    tracks[itemIndex].enabled = !tracks[itemIndex].enabled;
                    break;
            }

            LoadMidiItems();
        }


        private ListViewHitTestInfo GetHitInfo()
        {
            Point mousePos = PointToClient(MousePosition);
            ListViewHitTestInfo hitTestInfo = HitTest(mousePos);
            return hitTestInfo;
        }

        private int GetColumnIndexFromHit(ListViewHitTestInfo info)
        {
            return info.Item.SubItems.IndexOf(info.SubItem);
        }

        public void UpdateTrackInstrument(int trackIndex)
        {
            InstrumentIndexForm indexForm = new InstrumentIndexForm();
            indexForm.SetInstrumentId(tracks[trackIndex].instrumentId);
            if (indexForm.ShowDialog(this) == DialogResult.OK)
            {
                tracks[trackIndex].instrumentId = indexForm.instrumentId;
            }

            LoadMidiItems();
        }

        public void UpdateTrackPitchShift(int trackIndex)
        {
            PitchShiftForm pitchShiftForm = new PitchShiftForm();
            pitchShiftForm.SetPitchShift(tracks[trackIndex].pitchShiftId);
            if (pitchShiftForm.ShowDialog(this) == DialogResult.OK)
            {
                tracks[trackIndex].pitchShiftId = pitchShiftForm.pitchShift;
            }

            LoadMidiItems();
        }

        public void UpdateTrackChannel(int trackIndex)
        {
            ChannelIndexForm channelIndexForm = new ChannelIndexForm();
            channelIndexForm.SetChannelId(tracks[trackIndex].channel);
            if(channelIndexForm.ShowDialog(this) == DialogResult.OK)
            {
                tracks[trackIndex].channel = channelIndexForm.channelId;
            }

            LoadMidiItems();
        }


        private bool IsTrackEnabled(int trackIndex)
        {
            if (tracks == null || tracks.Count == 0)
            {
                return false;
            }

            return tracks[trackIndex].enabled;
        }

        // Draw the values in the columns
        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            TextFormatFlags flags;
            e.DrawBackground();

            switch ((TrackColumn)e.ColumnIndex)
            {
                case TrackColumn.Name:
                    flags = TextFormatFlags.Left;
                    break;
                default:
                    flags = TextFormatFlags.HorizontalCenter;
                    break;
            }

            flags |= TextFormatFlags.VerticalCenter;

            // If it's the leftmost one, I wanna draw a checkbox
            if (tracks.Count <= 0)
            {
                return;
            }

            switch ((TrackColumn)e.ColumnIndex)
            {
                case TrackColumn.Enabled:
                    Image image;
                    image = IsTrackEnabled(e.ItemIndex) ? checkedBox : unCheckedBox;

                    Point point = e.Bounds.Location;
                    point.X += (columnSize - imageSize) / 2;
                    point.Y += (rowHeight - imageSize) / 2;

                    e.Graphics.DrawImage(image, point.X, point.Y, imageSize, imageSize);
                    break;
                default:
                    e.DrawText(flags);
                    break;
            }

        }

        // Basically default draw code needed to make it exist in this dimension
        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {

        }

    }
}
