using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimationEditor
{
    public class SelectionChangedEventArgs : EventArgs
    {
        public AnimSelection Selection { get; private set; }

        public SelectionChangedEventArgs(AnimSelection s)
        {
            Selection = s;
        }

    }
}
