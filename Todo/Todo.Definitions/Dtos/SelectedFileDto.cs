﻿using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos
{
    public class SelectedFileDto
    {
		public Course Course
		{
			get;
			private set;
		}

        public File File
        {
            get;
            private set;
        }

        public SelectedFileDto(Course course, File file)
        {
            Course = course;
            File = file;
        }
    }
}
