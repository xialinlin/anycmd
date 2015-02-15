﻿
namespace Anycmd.Ac.ViewModels.Infra.DicViewModels
{
    using Engine;
    using Engine.Ac.InOuts;
    using Engine.Ac.Messages.Infra;
    using Engine.InOuts;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class DicItemCreateInput : EntityCreateInput, IDicItemCreateIo
    {
        public DicItemCreateInput()
        {
            HecpOntology = "DicItem";
            HecpVerb = "Create";
        }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public Guid DicId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(1)]
        public int IsEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int SortCode { get; set; }

        public override IAnycmdCommand ToCommand(IAcSession acSession)
        {
            return new AddDicItemCommand(acSession, this);
        }
    }
}
