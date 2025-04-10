﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarsAndConflicts.DataAccess.Entities
{
    public class WarEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public byte[] Image { get; set; } = null!;

        public Guid PeriodId { get; set; }

        public virtual PeriodEntity Period { get; set; } = null!;

        public virtual ICollection<CommentEntity> Comments { get; set; } = [];
    }
}
